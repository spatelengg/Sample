using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Domain.Common;

namespace Sample.Domain.Entities
{
    public class UserCredential : BaseEntity
    {
        public string Salt { get; set; }
        public string Password { get; set; }
    }
}
