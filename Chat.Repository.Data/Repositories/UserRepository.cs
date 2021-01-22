using Chat.Repository.Core.EntityModel;
using Chat.Repository.Core.Repositories;
using Chat.Repository.Data.Contexts;

namespace Chat.Repository.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(SqlDbContext context) : base(context)
        {

        }
    }
}
