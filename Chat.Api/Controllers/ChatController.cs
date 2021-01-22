using Chat.Api.SignalR;
using Chat.Core.Services;
using Chat.Repository.Core.EntityModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        private readonly IChatHistoryService _iChatHistoryService;

        public ChatController(IHubContext<BroadcastHub, IHubClient> hubContext, IChatHistoryService iChatHistoryService)
        {
            _hubContext = hubContext;
            _iChatHistoryService = iChatHistoryService;
        }

        [HttpPost("Add")]
        public async Task<ChatHistory> Add([FromBody] ChatHistory obj) //Use DTO
        {
            var result = await _iChatHistoryService.AddAsync(obj);
            await _hubContext.Clients.All.BroadcastMessage("broadcastNewChat");
            return result;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<ChatHistory>> GetAll(long senderUserId, long recipientUserId)  
        {
            var result = await _iChatHistoryService.GetAllAsync(a=> (a.SenderUserId == senderUserId && a.RecipientUserId == recipientUserId) || a.RecipientUserId == senderUserId && a.SenderUserId == recipientUserId);
            return result;
        }

        [HttpDelete("Delete")]
        public async Task<bool> Delete(long id)
        {
            var result = await _iChatHistoryService.Delete(id);
            return result;
        }
    }
}
