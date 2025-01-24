using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Application.Repository;
using Sample.Domain.Entities;

namespace Sample.Infrastructure.Persistence.Repository
{
    public class UserCredentialRepository : BaseRepository<UserCredential>, IUserCredentialRepository
    {
        public UserCredentialRepository(SampleDBContext context) : base(context)
        {
        }
    }
}
