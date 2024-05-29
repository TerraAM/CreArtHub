using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Adapter;
using CreArtHub.Domain.Entity;
using Microsoft.AspNetCore.Components.RenderTree;

namespace CreArtHub.Client.Controllers
{
    public class CommentController : Controller
    {
        private readonly WebDBContext _context;

        public CommentController(WebDBContext context)
        {
            _context = context;
        }

        // GET: Comment
        public async Task<IActionResult> Index()
        {
            var webDBContext = _context.Comments.Include(c => c.Author).Include(c => c.Post);
            return View(await webDBContext.ToListAsync());
        }

        // GET: Comment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .Include(c => c.Author)
                .Include(c => c.Post)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // GET: Comment/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Name");
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Title");
            return View();
        }

        // POST: Comment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PostId,AuthorId,Content,CreatedAt,IsEdit")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Name", comment.AuthorId);
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Title", comment.PostId);
            return View(comment);
        }

        // GET: Comment/Edit/5
        public async Task<IActionResult> Edit(int? id,string url)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Name", comment.AuthorId);
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Title", comment.PostId);
            ViewBag.Referrer = url;
            return View(comment);
        }

        // POST: Comment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,string url, [Bind("Id,PostId,AuthorId,Content,CreatedAt,IsEdit")] Comment comment)
        {
            if (id != comment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (User.IsInRole("admin") || User.IsInRole("moderator"))
                    {
                        _context.Update(comment);
                    }
                    else 
                    {
                        var editedComment = await _context.Comments.FindAsync(id);
                        editedComment.Content = comment.Content;
                        editedComment.IsEdit = true;
                        _context.Update(editedComment);
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(comment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                if (!string.IsNullOrEmpty(url))
                {
                    return Redirect(url);
                }
                else
                {
                    // В случае, если нет предыдущей страницы, можете перенаправить куда-то по умолчанию
                    return RedirectToAction("Index");
                }
            }
            ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Name", comment.AuthorId);
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Title", comment.PostId);
            return View(comment);
        }

        // GET: Comment/Delete/5
        public async Task<IActionResult> Delete(int? id, string url)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .Include(c => c.Author)
                .Include(c => c.Post)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comment == null)
            {
                return NotFound();
            }
            ViewBag.Referrer = url;
            return View(comment);
        }

        // POST: Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, string url)
        {
            var comment = await _context.Comments.FindAsync(id);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            if (!string.IsNullOrEmpty(url))
            {
                return Redirect(url);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}
