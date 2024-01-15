using Microsoft.AspNetCore.SignalR;
using Quark_Backend.Entities;
using Quark_Backend.Models;

namespace Quark_Backend.Hubs
{
    public class QuarkHub : Hub
    {
        public async Task BroadcastUser(User user)
        {
            await Clients.All.SendAsync("ReceiveUser", user);
        }

        public async Task PushMessage(string message, string username)
        {
            await Clients.All.SendAsync("ReceiveMessage", message, username);
        }

        public async Task JoinGroup(string groupName)
        {
            Console.WriteLine($"User {Context.ConnectionId} is joining group {groupName}");
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task PushToGroup(string groupName, MessageModel message)
        {   
            await Clients.Group(groupName).SendAsync("ReceiveMessageGroup", message);
        }
    }
}
