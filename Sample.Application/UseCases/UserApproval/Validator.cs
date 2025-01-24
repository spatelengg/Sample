using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Sample.Domain;

namespace Sample.Application.UseCases.UserApproval
{
    public sealed class Validator : AbstractValidator<UserApprovalRequest>
    {
        public Validator()
        {
            var conditions = new List<UserStatus>() { UserStatus.Approved, UserStatus.Declined };
            RuleFor(x => x.Status).Must(x => conditions.Contains(x))
                .WithMessage("Please accept or decline user");
        }
    }
}
