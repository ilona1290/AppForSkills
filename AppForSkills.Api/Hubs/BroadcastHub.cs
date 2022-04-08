using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppForSkills.Api.Hubs
{
    public class BroadcastHub : Hub
    {
        public async Task SendMessage(string receiver)
        {
            await Clients.All.SendAsync("ReceiveMessage", receiver);
        }
    }
}
