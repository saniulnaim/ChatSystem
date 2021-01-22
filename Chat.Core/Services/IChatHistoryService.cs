using Chat.Repository.Core.EntityModel;
using System.Threading.Tasks;

namespace Chat.Core.Services
{
    public interface IChatHistoryService : IBaseService<ChatHistory>
    {
        Task<bool> Delete(long id);
    }
}
