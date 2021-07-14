using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tryProject.Data;
using tryProject.Models;

namespace tryProject.Controllers
{
    public class ForumCategoryTagsController : Controller
    {
        private readonly tryProjectContext _context;

        public ForumCategoryTagsController(tryProjectContext context)
        {
            _context = context;
        }

        // GET: ForumCategoryTags
        public async Task<IActionResult> Index()
        {
            return View(await _context.ForumCategoryTag.ToListAsync());
        }

        // GET: ForumCategoryTags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forumCategoryTag = await _context.ForumCategoryTag
                .FirstOrDefaultAsync(m => m.Id == id);
            if (forumCategoryTag == null)
            {
                return NotFound();
            }

            return View(forumCategoryTag);
        }

        // GET: ForumCategoryTags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ForumCategoryTags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ForumCategoryTag forumCategoryTag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(forumCategoryTag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(forumCategoryTag);
        }

        // GET: ForumCategoryTags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forumCategoryTag = await _context.ForumCategoryTag.FindAsync(id);
            if (forumCategoryTag == null)
            {
                return NotFound();
            }
            return View(forumCategoryTag);
        }

        // POST: ForumCategoryTags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ForumCategoryTag forumCategoryTag)
        {
            if (id != forumCategoryTag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forumCategoryTag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForumCategoryTagExists(forumCategoryTag.Id))
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
            return View(forumCategoryTag);
        }

        // GET: ForumCategoryTags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forumCategoryTag = await _context.ForumCategoryTag
                .FirstOrDefaultAsync(m => m.Id == id);
            if (forumCategoryTag == null)
            {
                return NotFound();
            }

            return View(forumCategoryTag);
        }

        // POST: ForumCategoryTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var forumCategoryTag = await _context.ForumCategoryTag.FindAsync(id);
            _context.ForumCategoryTag.Remove(forumCategoryTag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForumCategoryTagExists(int id)
        {
            return _context.ForumCategoryTag.Any(e => e.Id == id);
        }
    }
}
