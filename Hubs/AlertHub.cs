using System.Threading.Tasks;
using BlushMe.Data;
using Microsoft.AspNetCore.SignalR;

namespace BlushMe.Hubs
{
    public class AlertHub: Hub
    {
        private readonly BlushDbContext _context;
        public AlertHub(BlushDbContext context)
        {
            _context = context;
        }
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        
        public async Task UpdateAppt(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        public async Task DeleteAppt(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        public async Task AddAppt(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}