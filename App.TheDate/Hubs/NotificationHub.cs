using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.TheDate.Hubs
{
    public class NotificationHub : Hub
    {
        [Authorize(Roles = "User,Admin,Moderator")]
        public async Task SendNotification(string userName, string content)
        {
            await Clients.User(userName).SendAsync("ReceiveMessage", userName, content);
        }
    }
}
