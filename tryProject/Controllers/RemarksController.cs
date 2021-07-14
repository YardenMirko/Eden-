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
    public class RemarksController : Controller
    {
        private readonly tryProjectContext _context;

        public RemarksController(tryProjectContext context)
        {
            _context = context;
        }

        // GET: Remarks
        public async Task<IActionResult> Index()
        {
            var tryProjectContext = _context.Remark.Include(r => r.Commet);
            return View(await tryProjectContext.ToListAsync());
        }

        // GET: Remarks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var remark = await _context.Remark
                .Include(r => r.Commet)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (remark == null)
            {
                return NotFound();
            }

            return View(remark);
        }

        // GET: Remarks/Create
        public IActionResult Create()
        {
            ViewData["CommentId"] = new SelectList(_context.Comment, "Id", "Id");
            return View();
        }

        // POST: Remarks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CommentId,Body,RemarkTime")] Remark remark)
        {
            if (ModelState.IsValid)
            {
                _context.Add(remark);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CommentId"] = new SelectList(_context.Comment, "Id", "Id", remark.CommentId);
            return View(remark);
        }

        // GET: Remarks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var remark = await _context.Remark.FindAsync(id);
            if (remark == null)
            {
                return NotFound();
            }
            ViewData["CommentId"] = new SelectList(_context.Comment, "Id", "Id", remark.CommentId);
            return View(remark);
        }

        // POST: Remarks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CommentId,Body,RemarkTime")] Remark remark)
        {
            if (id != remark.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(remark);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RemarkExists(remark.Id))
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
            ViewData["CommentId"] = new SelectList(_context.Comment, "Id", "Id", remark.CommentId);
            return View(remark);
        }

        // GET: Remarks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var remark = await _context.Remark
                .Include(r => r.Commet)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (remark == null)
            {
                return NotFound();
            }

            return View(remark);
        }

        // POST: Remarks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var remark = await _context.Remark.FindAsync(id);
            _context.Remark.Remove(remark);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RemarkExists(int id)
        {
            return _context.Remark.Any(e => e.Id == id);
        }
    }
}
