using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Sample.Domain;

namespace Sample.Application.UseCases.UserRegistration
{
    public sealed record UserRegistrationRequest(Guid Id, string Password, string Name, string PhoneNumber, string LinkedInURL, string AliasName)
        : IRequest<UserRegistrationResponse>;

}
