using System;
using System.Threading.Tasks;
 
namespace Chat.Repository.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IChatHistoryRepository IChatHistoryRepository { get; }
        IUserRepository IUserRepository { get; }


        Task<int> CommitAsync();
    }
}
