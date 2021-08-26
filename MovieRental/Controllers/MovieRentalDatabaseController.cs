using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieRental.Data;
using MovieRental.Models;

namespace MovieRental.Controllers
{
    public class MovieRentalDatabaseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieRentalDatabaseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MovieRentalDatabase
        public async Task<IActionResult> Index()
        {
            return View(await _context.MovieRentalDatabase.ToListAsync());
        }

        // GET: MovieRentalDatabase/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieRentalDatabase = await _context.MovieRentalDatabase
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieRentalDatabase == null)
            {
                return NotFound();
            }

            return View(movieRentalDatabase);
        }

        // GET: MovieRentalDatabase/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovieRentalDatabase/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Genre,Producer,Year,Length")] MovieRentalDatabase movieRentalDatabase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieRentalDatabase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movieRentalDatabase);
        }

        // GET: MovieRentalDatabase/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieRentalDatabase = await _context.MovieRentalDatabase.FindAsync(id);
            if (movieRentalDatabase == null)
            {
                return NotFound();
            }
            return View(movieRentalDatabase);
        }

        // POST: MovieRentalDatabase/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Genre,Producer,Year,Length")] MovieRentalDatabase movieRentalDatabase)
        {
            if (id != movieRentalDatabase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieRentalDatabase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieRentalDatabaseExists(movieRentalDatabase.Id))
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
            return View(movieRentalDatabase);
        }

        // GET: MovieRentalDatabase/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieRentalDatabase = await _context.MovieRentalDatabase
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieRentalDatabase == null)
            {
                return NotFound();
            }

            return View(movieRentalDatabase);
        }

        // POST: MovieRentalDatabase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieRentalDatabase = await _context.MovieRentalDatabase.FindAsync(id);
            _context.MovieRentalDatabase.Remove(movieRentalDatabase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieRentalDatabaseExists(int id)
        {
            return _context.MovieRentalDatabase.Any(e => e.Id == id);
        }
    }
}
