using Chat.Repository.Core.EntityModel;
using System.Threading.Tasks;

namespace Chat.Core.Services
{
    public interface IUserService : IBaseService<User>
    {
        Task<User> UpdateLoginStatus(string email);
        Task<User> UpdateLogoutStatus(string email);
    }
}
