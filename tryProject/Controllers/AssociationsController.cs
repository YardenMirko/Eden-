﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tryProject.Data;
using tryProject.Models;

namespace tryProject.Controllers
{
    public class AssociationsController : Controller
    {
        private readonly tryProjectContext _context;

        public AssociationsController(tryProjectContext context)
        {
            _context = context;
        }

        // GET: Associations
        public async Task<IActionResult> Index()
        {
            var checky = _context.Association.Include(x => x.Zones).Include(x => x.Purposes).Include(x => x.CommunityWorks).Include(x => x.CatersTo).ToListAsync();
            return View(await checky);
        }
        public async Task<IActionResult> Groupby()
        {
            IEnumerable<GroupManagerAssociations> g = from a in _context.Association
                                                      group a by new
                                                      {
                                                         a.City,
                                                         a.Name,

                                                      } into k
                                                      select new GroupManagerAssociations
                                                      {
                                                          Cname=k.Key.City,
                                                          Aname = k.Key.Name,
                                                      };
            return View(g.ToList());
        }

        // GET: Associations/Details/5
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var association = await _context.Association
                .Include(x => x.Zones)
                .Include(x => x.Purposes)
                .Include(x => x.CatersTo)
                .Include(x => x.CommunityWorks)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (association == null)
            {
                return NotFound();
            }
            return View(association);
        }

        // GET: Associations/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["Purposes"] = new SelectList(_context.Set<Purpose>(), nameof(Purpose.Id), nameof(Purpose.Name));
            ViewData["CommunityWorks"] = new SelectList(_context.Set<CommunityWorks>(), nameof(CommunityWorks.Id), nameof(CommunityWorks.Decscription));
            ViewData["Zones"] = new SelectList(_context.Set<Zone>(), nameof(Zone.Id), nameof(Zone.Name));
            ViewData["CatersTo"] = new SelectList(_context.Set<CatersTo>(), nameof(CatersTo.Id), nameof(CatersTo.Name));
            return View();
        }

        // POST: Associations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Name,City,PurposeName,CommunityWorksDescription,Manager,Website, Email, Logo,Introduction")] Association association, int[] Zones, int[] Purposes, int[] CateringTo, string Manager)
        {
            if (ModelState.IsValid)
            {
                association.Zones = new List<Zone>();
                association.Zones.AddRange(_context.Zone.Where(x => Zones.Contains(x.Id)));
                association.Purposes = new List<Purpose>();
                association.Purposes.AddRange(_context.Purpose.Where(x => Purposes.Contains(x.Id)));
                association.CatersTo = new List<CatersTo>();
                association.CatersTo.AddRange(_context.CatersTo.Where(x => CateringTo.Contains(x.Id)));
                association.Manager = new Manager { Name = Manager, AssociationId = association.Id, Association = association };
                _context.Add(association);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(association);
        }

        // GET: Associations/Edit/5
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var association = await _context.Association.FindAsync(id);
            if (association == null)
            {
                return NotFound();
            }
            ViewData["Zones"] = new SelectList(_context.Set<Zone>(), nameof(Zone.Id), nameof(Zone.Name));
            ViewData["CatersTo"] = new SelectList(_context.Set<CatersTo>(), nameof(CatersTo.Id), nameof(CatersTo.Name));
            ViewData["Purposes"] = new SelectList(_context.Set<Purpose>(), nameof(Purpose.Id), nameof(Purpose.Name));
            ViewData["CommunityWorks"] = new SelectList(_context.Set<CommunityWorks>(), nameof(CommunityWorks.Id), nameof(CommunityWorks.Decscription));
            return View(association);

        }

        // POST: Associations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,City,Purpose,CommunityWorks,Manager,Website, Email, Logo,Introduction")] Association association, int[] Zones, int[] Purposes, int[] CateringTo, string Manager)
        {
            if (id != association.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {

                    association.Zones = new List<Zone>();
                    association.Zones.AddRange(_context.Zone.Where(x => Zones.Contains(x.Id)));
                    association.Purposes = new List<Purpose>();
                    association.Purposes.AddRange(_context.Purpose.Where(x => Purposes.Contains(x.Id)));
                    association.CatersTo = new List<CatersTo>();
                    association.CatersTo.AddRange(_context.CatersTo.Where(x => CateringTo.Contains(x.Id)));
                    association.Manager = new Manager { Name = Manager, AssociationId = association.Id, Association = association };
                    _context.Update(association);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssociationExists(association.Id))
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
            return View(association);

        }

        // GET: Associations/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var association = await _context.Association
                .FirstOrDefaultAsync(m => m.Id == id);
            if (association == null)
            {
                return NotFound();
            }

            return View(association);
        }

        // POST: Associations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var association = await _context.Association.FindAsync(id);
            _context.Association.Remove(association);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssociationExists(int id)
        {
            return _context.Association.Any(e => e.Id == id);
        }
    }
}
