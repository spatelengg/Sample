using Sample.Application;
using Sample.Application.Repository;
using Sample.Domain;
using Sample.Domain.Entities;


namespace Sample.Infrastructure.Persistence.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SampleDBContext context) : base(context)
        { 
       
        }

        public bool IsUserEmailExists(Guid userId, string email)
        {
            return Context.Users.Any(s => s.Email == email && s.Id != userId);
        }
    }
}
