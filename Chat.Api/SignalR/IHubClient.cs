using System.Threading.Tasks;

namespace Chat.Api.SignalR
{
    public interface IHubClient
    {
        Task BroadcastMessage(string operationType);
    }
}
