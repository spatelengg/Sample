using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Domain.Entities;

namespace Sample.Application.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        bool IsUserEmailExists(Guid userId, string email);
    }
}
