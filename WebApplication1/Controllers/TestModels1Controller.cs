using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1
{
    public class TestModels1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestModels1Controller(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: TestModels1
        public async Task<IActionResult> Index()
        {
            return View(await _context.TestModel.ToListAsync());
        }

        // GET: TestModels1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testModel = await _context.TestModel.SingleOrDefaultAsync(m => m.Id == id);
            if (testModel == null)
            {
                return NotFound();
            }

            return View(testModel);
        }

        // GET: TestModels1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TestModels1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Text")] TestModel testModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(testModel);
        }

        // GET: TestModels1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testModel = await _context.TestModel.SingleOrDefaultAsync(m => m.Id == id);
            if (testModel == null)
            {
                return NotFound();
            }
            return View(testModel);
        }

        // POST: TestModels1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Text")] TestModel testModel)
        {
            if (id != testModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestModelExists(testModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(testModel);
        }

        // GET: TestModels1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testModel = await _context.TestModel.SingleOrDefaultAsync(m => m.Id == id);
            if (testModel == null)
            {
                return NotFound();
            }

            return View(testModel);
        }

        // POST: TestModels1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testModel = await _context.TestModel.SingleOrDefaultAsync(m => m.Id == id);
            _context.TestModel.Remove(testModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TestModelExists(int id)
        {
            return _context.TestModel.Any(e => e.Id == id);
        }
    }
}
