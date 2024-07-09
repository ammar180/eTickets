using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers;

public class ActorsController : Controller
{
    private readonly IDataHelper<Actor> context;

    public async Task<IActionResult> Index()
    {
        return View(await context.GetAll());
    }
    public async Task<IActionResult> Details(int id = 1)
    {
        return View(context.GetById(id));
    }
    // GET: /Actors/UpdateActor
    [HttpGet]
    public async Task<IActionResult> UpdateActor(int id = 1)
    {
        return View(context.GetById(id));
    }
    // Post: /Actors/UpdateActor
    [HttpPost]
    public async Task<IActionResult> UpdateActor(Actor actor)
    {
        try
        {
            if (ModelState.IsValid)
            {
                context.Update(actor);

                return View("Index", await context.GetAll());
            }
            throw new Exception();
        }
        catch 
        { 
            return View(actor);
        }
    }

}
