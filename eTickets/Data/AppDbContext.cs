using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor_Movie>().HasKey(option => new
        {
            option.MovieId,
            option.ActorId
        });

        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Producer> Producers { get; set; }
    public DbSet<Actor_Movie> Actors_Movies { get; set; }
}
