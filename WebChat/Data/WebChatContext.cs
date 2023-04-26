using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebChat.Models;

namespace WebChat.Data
{
    public class WebChatContext : DbContext
    {
        public WebChatContext (DbContextOptions<WebChatContext> options)
            : base(options)
        {
        }

        public DbSet<WebChat.Models.ChatEntryModel> ChatEntryModel { get; set; } = default!;
    }
}
