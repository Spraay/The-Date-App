using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.TheDate.Hubs
{
    public class NotificationHub : Hub
    {
        public Task SendNotification(Guid userId, string content)
        {
            return Clients.All.SendAsync("ReceiveMessage", content);
        }
    }
}
