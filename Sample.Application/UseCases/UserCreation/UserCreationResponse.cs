using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.UseCases.UserCreation
{
    public sealed record class UserCreationResponse
    {
        public Guid Id { get; set; }
    }
}
