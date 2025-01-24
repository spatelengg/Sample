using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace Sample.Application.UseCases.UserCreation
{
    public sealed class Validator:AbstractValidator<UserCreationRequest>
    {
        public Validator() {
            RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.PhoneNumber).MaximumLength(20);
            RuleFor(x => x.LinkedInURL).MaximumLength(200);
            RuleFor(x=> x.AliasName).MaximumLength(50);
        }

        public override ValidationResult Validate(ValidationContext<UserCreationRequest> context)
        {
            var res = base.Validate(context);
             
            return res;
        }
    }
}
