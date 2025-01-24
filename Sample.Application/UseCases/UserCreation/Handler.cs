using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Sample.Application.Common.Exceptions;
using Sample.Application.Repository;
using Sample.Domain.Entities;

namespace Sample.Application.UseCases.UserCreation
{
    public sealed class Handler : IRequestHandler<UserCreationRequest, UserCreationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public Handler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserCreationResponse> Handle(UserCreationRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            if (_userRepository.IsUserEmailExists(user.Id, user.Email))
            {
                throw new UserAlreadyExistsException();
            }

            bool isCreate = false;
            if (user.Id == Guid.Empty) {
                user.Id = Guid.NewGuid();
                isCreate = true;
            }
            user.Status = IsValid(user) ? Domain.UserStatus.ApprovalPending : Domain.UserStatus.Draft;


            if (isCreate)
            {
                _userRepository.Create(user);
            }
            else {
                _userRepository.Update(user);
            }
            
            await _unitOfWork.Save(cancellationToken);

            return _mapper.Map<UserCreationResponse>(user);
        }

        private bool IsValid(User user) {
            if (string.IsNullOrEmpty(user.Email))
                return false;
            if (string.IsNullOrEmpty(user.Name))
                return false;

            return true;
        }
    }
}
