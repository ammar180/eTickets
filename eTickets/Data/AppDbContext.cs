using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor_Movie>().HasKey(x => new { x.MovieId, x.ActorId });
    }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Cinema> Cinimas { get; set; }
    public DbSet<Producer> Producers { get; set; }
    public DbSet<Actor_Movie> Actors_Movies { get; set; }
}
