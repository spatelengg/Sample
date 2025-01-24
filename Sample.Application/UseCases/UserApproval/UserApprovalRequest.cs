using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Sample.Domain;

namespace Sample.Application.UseCases.UserApproval
{
    public sealed record UserApprovalRequest(Guid Id, UserStatus Status)
      : IRequest<UserApprovalResponse>;
}
