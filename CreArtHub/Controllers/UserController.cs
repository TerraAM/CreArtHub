using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Adapter;
using CreArtHub.Domain.Entity;
using Microsoft.AspNetCore.Http;
using CreArtHub.App.Interactors;
using CreArtHub.Shared.Dto;
using Microsoft.Extensions.Hosting;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace CreArtHub.Client.Controllers
{
    public class UserController : Controller
    {
        private readonly WebDBContext _context;

		public UserController(WebDBContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            var webDBContext = _context.Users.Include(u => u.Role);
            return View(await webDBContext.ToListAsync());
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name");
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoleId,AvatarPath,Name,Email,Password,About,Skills")] User user, IFormFile Avatar)
        {
            if (ModelState.IsValid)
            {
                if (Avatar != null && Avatar.Length > 0)
                {
					var fileName = Path.GetFileName(Avatar.FileName);
					var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Storage", "Avatars", fileName);

					using (var stream = new FileStream(user.AvatarPath, FileMode.Create))
                    {
                        await Avatar.CopyToAsync(stream);
                    }
                    user.AvatarPath = "/Storage/Avatars/" + fileName;
				}

                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name", user.RoleId);
            return View(user);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name", user.RoleId);
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RoleId,AvatarPath,Name,Email,Password,About,Skills")] User user, IFormFile Avatar)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Avatar != null && Avatar.Length > 0)
                    {
                        var fileName = Path.GetFileName(Avatar.FileName);
						var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Storage","Avatars", fileName);

						using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await Avatar.CopyToAsync(stream);
                        }

                        user.AvatarPath = "/Storage/Avatars/" + fileName;

					}

                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name", user.RoleId);
            return View(user);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
