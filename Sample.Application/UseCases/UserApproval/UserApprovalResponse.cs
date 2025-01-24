using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.UseCases.UserApproval
{
    public sealed record class UserApprovalResponse
    {
        public Guid Id { get; set; }
    }
}
