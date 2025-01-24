using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Sample.Domain;

namespace Sample.Application.UseCases.UserCreation
{
    public sealed record UserCreationRequest(Guid Id,string Email, string Name, string PhoneNumber, string LinkedInURL, UserRole Role, string AliasName)
        : IRequest<UserCreationResponse>;

}
