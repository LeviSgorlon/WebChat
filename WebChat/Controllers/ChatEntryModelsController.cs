using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebChat.Data;
using WebChat.Models;

namespace WebChat.Controllers
{
    public class ChatEntryModelsController : Controller
    {
        private readonly WebChatContext _context;

        public ChatEntryModelsController(WebChatContext context)
        {
            _context = context;
        }

        // GET: ChatEntryModels
        public async Task<IActionResult> Index()
        {
              return _context.ChatEntryModel != null ? 
                          View(await _context.ChatEntryModel.ToListAsync()) :
                          Problem("Entity set 'WebChatContext.ChatEntryModel'  is null.");
        }

        // GET: ChatEntryModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ChatEntryModel == null)
            {
                return NotFound();
            }

            var chatEntryModel = await _context.ChatEntryModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chatEntryModel == null)
            {
                return NotFound();
            }

            return View(chatEntryModel);
        }

        // GET: ChatEntryModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChatEntryModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,User,Message,Time")] ChatEntryModel chatEntryModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chatEntryModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chatEntryModel);
        }

        // GET: ChatEntryModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ChatEntryModel == null)
            {
                return NotFound();
            }

            var chatEntryModel = await _context.ChatEntryModel.FindAsync(id);
            if (chatEntryModel == null)
            {
                return NotFound();
            }
            return View(chatEntryModel);
        }

        // POST: ChatEntryModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,User,Message,Time")] ChatEntryModel chatEntryModel)
        {
            if (id != chatEntryModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chatEntryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChatEntryModelExists(chatEntryModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(chatEntryModel);
        }

        // GET: ChatEntryModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ChatEntryModel == null)
            {
                return NotFound();
            }

            var chatEntryModel = await _context.ChatEntryModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chatEntryModel == null)
            {
                return NotFound();
            }

            return View(chatEntryModel);
        }
     

        // POST: ChatEntryModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ChatEntryModel == null)
            {
                return Problem("Entity set 'WebChatContext.ChatEntryModel'  is null.");
            }
            var chatEntryModel = await _context.ChatEntryModel.FindAsync(id);
            if (chatEntryModel != null)
            {
                _context.ChatEntryModel.Remove(chatEntryModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: ChatEntryModels/Chat/
        public async Task<IActionResult> Chat()
        {
            return _context.ChatEntryModel != null ?
                           View(await _context.ChatEntryModel.ToListAsync()) :
                           Problem("Entity set 'WebChatContext.ChatEntryModel'  is null.");
        }


        private bool ChatEntryModelExists(int id)
        {
          return (_context.ChatEntryModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
