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
    public class ForumsController : Controller
    {
        private readonly tryProjectContext _context;

        public ForumsController(tryProjectContext context)
        {
            _context = context;
        }

        // GET: Forums
        public async Task<IActionResult> Index()
        {
            var tryProjectContext = _context.Forum.Include(f => f.ForumCategory);
            return View(await tryProjectContext.ToListAsync());
        }

        public async Task<IActionResult> Search(string queryTitle, string queryBody, string queryForumCategory)
        {
            var q = from a in _context.Forum.Include(a => a.ForumCategory)
                    where (a.Title.Contains(queryTitle) && a.Body.Contains(queryBody) && a.ForumCategory.Name.Contains(queryForumCategory))
                    orderby a.Title descending
                    select a;

            var tryProjectContext = _context.Forum.Include(a => a.ForumCategory).Where(a => (a.Title.Contains(queryTitle) || queryTitle == null) && (a.Body.Contains(queryBody) || queryBody == null) && (a.ForumCategory.Name.Contains(queryForumCategory) || (queryForumCategory == null)));
            return View("Index", await tryProjectContext.ToListAsync());
        }


        // GET: Forums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forum = await _context.Forum
                .Include(f => f.ForumCategory)
                .Include(f => f.Comments)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (forum == null)
            {
                return NotFound();
            }
            ViewData["Comments"] = new SelectList(_context.Set<Comment>(), nameof(Comment.Id), nameof(Comment.Description));
            return View(forum);
        }

        // GET: Forums/Create
        public IActionResult Create()
        {
            ViewData["ForumCategoryId"] = new SelectList(_context.Set<ForumCategory>(), nameof(ForumCategory.Id), nameof(ForumCategory.Name));
            return View();
        }

        // POST: Forums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Body,DatePublished,ForumCategoryId")] Forum forum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(forum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ForumCategoryId"] = new SelectList(_context.Set<ForumCategory>(), nameof(ForumCategory.Id), nameof(ForumCategory.Name));
            return View(forum);
        }

        // GET: Forums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forum = await _context.Forum.FindAsync(id);
            if (forum == null)
            {
                return NotFound();
            }
            ViewData["ForumCategoryId"] = new SelectList(_context.Set<ForumCategory>(), nameof(ForumCategory.Id), nameof(ForumCategory.Name));
            return View(forum);
        }

        // POST: Forums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Body,DatePublished,ForumCategoryId")] Forum forum)
        {
            if (id != forum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForumExists(forum.Id))
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
            ViewData["ForumCategoryId"] = new SelectList(_context.Set<ForumCategory>(), nameof(ForumCategory.Id), nameof(ForumCategory.Name));
            return View(forum);
        }

        // GET: Forums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forum = await _context.Forum
                .Include(f => f.ForumCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (forum == null)
            {
                return NotFound();
            }

            return View(forum);
        }

        // POST: Forums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var forum = await _context.Forum.FindAsync(id);
            _context.Forum.Remove(forum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForumExists(int id)
        {
            return _context.Forum.Any(e => e.Id == id);
        }
    }
}
