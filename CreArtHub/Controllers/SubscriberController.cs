using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Adapter;
using CreArtHub.Domain.Entity;
using Microsoft.VisualBasic;
using CreArtHub.App.Interactors;
using CreArtHub.Shared.Dto;

namespace CreArtHub.Client.Controllers
{
    public class SubscriberController : Controller
    {
        private readonly WebDBContext _context;
        private readonly SubscriberInteractor interactor;

        public SubscriberController(WebDBContext context, SubscriberInteractor interactor)
        {
            _context = context;
            this.interactor = interactor;
        }

        // GET: Subscriber
        public async Task<IActionResult> Index()
        {
            Response<IEnumerable<SubscriberDto>> response;
            if (User.IsInRole("admin"))
            {
                response = await interactor.GetAll();
            }
            else {
                response = await interactor.GetMyAllByEmail(User.Identity.Name);
            }
            return View(response.Value);
        }

        // GET: Subscriber/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriber = await _context.Subscribers
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subscriber == null)
            {
                return NotFound();
            }

            return View(subscriber);
        }

        // GET: Subscriber/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name");
            return View();
        }

        // POST: Subscriber/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SubscribtionId,UserId")] Subscriber subscriber)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subscriber);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", subscriber.UserId);
            return View(subscriber);
        }

        // GET: Subscriber/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriber = await _context.Subscribers.FindAsync(id);
            if (subscriber == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", subscriber.UserId);
            return View(subscriber);
        }

        // POST: Subscriber/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SubscribtionId,UserId")] Subscriber subscriber)
        {
            if (id != subscriber.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subscriber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubscriberExists(subscriber.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", subscriber.UserId);
            return View(subscriber);
        }

        // GET: Subscriber/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriber = await _context.Subscribers
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subscriber == null)
            {
                return NotFound();
            }

            return View(subscriber);
        }

        // POST: Subscriber/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subscriber = await _context.Subscribers.FindAsync(id);
            _context.Subscribers.Remove(subscriber);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubscriberExists(int id)
        {
            return _context.Subscribers.Any(e => e.Id == id);
        }

        public async Task<IActionResult> My()
        {
            var response = await interactor.GetMyAllByEmail(User.Identity.Name);
            return View(response.Value);
        }
    }
}
