using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain
{
    public enum UserRole : byte
    {
        Admin,
        Approver,
        User
    }

    public enum UserStatus : byte
    {
        Draft,
        ApprovalPending,
        Approved,
        Declined,
        Created,
        Deleted
    }
}
