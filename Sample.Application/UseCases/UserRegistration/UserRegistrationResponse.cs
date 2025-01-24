using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.UseCases.UserRegistration
{
    public sealed record class UserRegistrationResponse
    {
        public Guid Id { get; set; }
    }
}
