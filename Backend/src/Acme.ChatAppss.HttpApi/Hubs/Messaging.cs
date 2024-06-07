using Acme.ChatApp.Messages;
using Acme.ChatAppss.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.SignalR;
using Volo.Abp.Users;

namespace Acme.ChatApp.Hubs
{
    [HubRoute("/chat")]
    public class Messaging : AbpHub
    {
        private readonly IUserConnectionService _userConnectionService;
        private readonly ChatAppssDbContext _context;

        public Messaging(IUserConnectionService userConnectionService, ChatAppssDbContext context)
        {
            _userConnectionService = userConnectionService;
            _context = context;
        }
        public override async Task OnConnectedAsync()
        {
            var connectionId = Context.ConnectionId;

            string userId = Context.UserIdentifier;

            await _userConnectionService.AddConnectionAsync(userId, connectionId);

            await base.OnConnectedAsync();
        }

        public async Task SendMessage(MessageDto message)
        {
            var userId = Context.UserIdentifier;

            var receiverConnectionId = await _userConnectionService.GetConnectionIdAsync(Convert.ToString(message.ReceiverId));

           await Clients.Client(receiverConnectionId).SendAsync("ReceiveOne", message, userId);
        }

        public async Task SendEditedMessage(MessageDto message)
        {
            var userId = Context.UserIdentifier;

            var receiverConnectionId = await _userConnectionService.GetConnectionIdAsync(Convert.ToString(message.ReceiverId));

           await Clients.Client(receiverConnectionId).SendAsync("ReceiveEdited", message);
        }

        public async Task SendDeletedMessage(MessageDto message)
        {
            var userId = Context.UserIdentifier;

            var receiverConnectionId = await _userConnectionService.GetConnectionIdAsync(Convert.ToString(message.ReceiverId));

            await Clients.Client(receiverConnectionId).SendAsync("ReceiveDeleted", message);
        }
    }
}
