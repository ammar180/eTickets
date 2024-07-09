using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class MovieService : IDataHelper<Movie>
    {
        private readonly AppDbContext context;
        public MovieService(AppDbContext appDbContext)
        {
            context = appDbContext;
        }
        public void Add(Movie movie)
        {
            try
            {
                context.Movies.Add(movie);
                context.SaveChanges();

            }
            catch { }
        }

        public void Delete(int id)
        {
            try
            {
                var movie = context.Movies.First(x => x.MovieId == id);
                context.Movies.Remove(movie);
                context.SaveChanges();
            }
            catch { }
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await context.Movies.ToListAsync();
        }

        public Movie GetById(int id)
        {
            try
            {
                return context.Movies.FirstOrDefault(x => x.MovieId == id);

            }
            catch { return new Movie(); }
        }

        public void Update(Movie movie)
        {
            try
            {
                context.Movies.Update(movie);
                context.SaveChanges();
            }
            catch { }
        }
    }
}
