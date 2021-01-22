using Chat.Repository.Core.Repositories;
using Chat.Repository.Data.Contexts;
using System.Threading.Tasks;

namespace Chat.Repository.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Declaration & Construction & Dispose & Commit
        private readonly SqlDbContext _context;

        public UnitOfWork(SqlDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        #endregion Declaration & Construction & Dispose & Commit


        #region RepositoryEntity
        private ChatHistoryRepository ChatHistoryRepository;
        private UserRepository UserRepository;
        #endregion RepositoryEntity

        #region Declaration
        public IChatHistoryRepository IChatHistoryRepository => ChatHistoryRepository = ChatHistoryRepository ?? new ChatHistoryRepository(_context);
        public IUserRepository IUserRepository => UserRepository = UserRepository ?? new UserRepository(_context);
        #endregion Declaration
    }
}
