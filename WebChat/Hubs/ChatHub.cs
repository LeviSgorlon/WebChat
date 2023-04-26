using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WebChat.Data;
using WebChat.Models;

namespace WebChat.Hubs{

    
        public class ChatHub : Hub
        {
        private readonly WebChatContext _context;

        public ChatHub(WebChatContext context)
        {
            _context = context;
        }

        public async Task SendMessage(string user, string message,string date)
        {
            
            var ModelState = await _context.ChatEntryModel.FirstOrDefaultAsync();
            if (ModelState != null)
            {
                ChatEntryModel Message = new ChatEntryModel();
                Message.User = user;
                Message.Message = message;
                Message.Time = date;
                _context.Add(Message);
                await _context.SaveChangesAsync();
                
            }
            await Clients.All.SendAsync("ReceiveMessage", user, message, date);
        }
       


    }
}

