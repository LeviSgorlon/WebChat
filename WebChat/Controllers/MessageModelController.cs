using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace WebChat.Controllers
{
    public class MessageModelController : Controller
    {
        // 
        // GET: /Pages/
        // Requires using System.Text.Encodings.Web;
        public string Index()
        {
            return "Index";
        }
        // 
        // GET: /Pages/Welcome/ 
        // Requires using System.Text.Encodings.Web;
        public IActionResult Welcome(string name, int ID = 1)
        {
            return View();
        }
    }
}
