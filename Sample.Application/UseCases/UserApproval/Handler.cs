using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Sample.Application.Common.Exceptions;
using Sample.Application.Repository;
using Sample.Application.Service;
using Sample.Domain.Entities;

namespace Sample.Application.UseCases.UserApproval
{
    public sealed class Handler : IRequestHandler<UserApprovalRequest, UserApprovalResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public Handler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<UserApprovalResponse> Handle(UserApprovalRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(request.Id, cancellationToken);

            if (user == null || (user.Status != Domain.UserStatus.ApprovalPending))
            {
                throw new InvalidRequestParameter();
            }

            user.Status = request.Status;
            _userRepository.Update(user);
            await _unitOfWork.Save(cancellationToken);

            if (user.Status == Domain.UserStatus.Approved) {
                await _emailService.SendEmailAsync(user.Email, "admin@mysite.com"
                    , $"Welcome: {user.Name}"
                    , $"User account created for {user.Name}. Please set your password.");
            }

            return _mapper.Map<UserApprovalResponse>(user);

        }
    }
}
