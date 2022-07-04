using System.Collections.Generic;
using System.Threading.Tasks;
using TaskProject.Core.Database.Abstractions;
using TaskProject.Core.Models;

namespace TaskProject.Core.Database.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IDatabase _db;

        public MovieRepository(IDatabase db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await _db.Connection.Table<Movie>().ToListAsync();
        }

        public async Task AddMovie(Movie movie)
        {
            await _db.Connection.InsertAsync(movie);
        }
    }
}