using Chat.Repository.Core.EntityModel;
using Chat.Repository.Core.Repositories;
using Chat.Repository.Data.Contexts;

namespace Chat.Repository.Data.Repositories
{
    public class ChatHistoryRepository : Repository<ChatHistory>, IChatHistoryRepository
    {
        public ChatHistoryRepository(SqlDbContext context) : base(context)
        {

        }
    }
}
