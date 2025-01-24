using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Sample.Application.Common.Exceptions;
using Sample.Application.Repository;
using Sample.Domain.Entities;

namespace Sample.Application.UseCases.UserRegistration
{
    public sealed class Handler : IRequestHandler<UserRegistrationRequest, UserRegistrationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IUserCredentialRepository _userCredRepository;


        public Handler(IUnitOfWork unitOfWork, IUserRepository userRepository, IUserCredentialRepository userCredRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _userCredRepository = userCredRepository;
            _mapper = mapper;
        }

        public async Task<UserRegistrationResponse> Handle(UserRegistrationRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(request.Id, cancellationToken);
            if (user == null)
            {
                throw new InvalidRequestParameter();
            }

            var cred = await _userCredRepository.Get(request.Id, cancellationToken);
            if (cred == null)
            {
                cred = new UserCredential()
                {
                    Id = request.Id
                };
                _userCredRepository.Create(cred);
            }
            else {
                _userCredRepository.Update(cred);
            }
            
            cred.Password = request.Password;
            user.PhoneNumber = request.PhoneNumber;
            user.Name = request.Name;
            user.AliasName = request.AliasName;
            user.LinkedInUrl = request.LinkedInURL;
          
            _userRepository.Update(user);

            await _unitOfWork.Save(cancellationToken);

            return _mapper.Map<UserRegistrationResponse>(user);

        }
    }
}
