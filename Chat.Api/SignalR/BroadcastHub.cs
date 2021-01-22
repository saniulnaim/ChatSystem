using Microsoft.AspNetCore.SignalR;

namespace Chat.Api.SignalR
{
    public class BroadcastHub : Hub<IHubClient>
    {
    }
}
