using eTickets.Data;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers;

public class ActorsController : Controller
{
    private readonly AppDbContext context;
    public ActorsController(AppDbContext _context)
    {
        context = _context;
    }

    public async Task<IActionResult> Index()
    {
        var allActors = await context.Actors.ToListAsync();
        return View(allActors);
    }
    public async Task<IActionResult> Details(int id = 1)
    {
        var actor = await context.Actors.FirstOrDefaultAsync(x => x.ActorId == id);
        return View(actor);
    }
    // GET: /Actors/UpdateActor
    [HttpGet]
    public async Task<IActionResult> UpdateActor(int id = 1)
    {
        var actor = await context.Actors.FirstOrDefaultAsync(x => x.ActorId == id);
        return View(actor);
    }
    // Post: /Actors/UpdateActor
    [HttpPost]
    public async Task<IActionResult> UpdateActor(Actor actor)
    {
        try
        {
            context.Actors.Update(actor);
            context.SaveChanges();


            return View("Index", await context.Actors.ToListAsync());
        }
        catch 
        { 
            return View(actor);
        }
    }

}
