using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eTickets.Data;
using eTickets.Models;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Movies.Include(m => m.Cinema).Include(m => m.Producer);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(m => m.Cinema)
                .Include(m => m.Producer)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            ViewData["CinemasId"] = new SelectList(_context.Cinemas, "CinemasId", "CinemasId");
            ViewData["ProducerId"] = new SelectList(_context.Producers, "ProducerId", "ProducerId");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,MovieName,Description,Price,MovieImageURL,StartDate,EndDate,MovieCategory,CinemasId,ProducerId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CinemasId"] = new SelectList(_context.Cinemas, "CinemasId", "CinemasId", movie.CinemasId);
            ViewData["ProducerId"] = new SelectList(_context.Producers, "ProducerId", "ProducerId", movie.ProducerId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            ViewData["CinemasId"] = new SelectList(_context.Cinemas, "CinemasId", "CinemasId", movie.CinemasId);
            ViewData["ProducerId"] = new SelectList(_context.Producers, "ProducerId", "ProducerId", movie.ProducerId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,MovieName,Description,Price,MovieImageURL,StartDate,EndDate,MovieCategory,CinemasId,ProducerId")] Movie movie)
        {
            if (id != movie.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.MovieId))
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
            ViewData["CinemasId"] = new SelectList(_context.Cinemas, "CinemasId", "CinemasId", movie.CinemasId);
            ViewData["ProducerId"] = new SelectList(_context.Producers, "ProducerId", "ProducerId", movie.ProducerId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(m => m.Cinema)
                .Include(m => m.Producer)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.MovieId == id);
        }

        [HttpPost]
        public async Task<IActionResult> Search([Bind("MovieName")] Movie m)
        {
            var appDbContext = _context.Movies.Where(x => x.MovieName.Contains(m.MovieName));
            return View("Index",await appDbContext.ToListAsync());
        }
    }
}
