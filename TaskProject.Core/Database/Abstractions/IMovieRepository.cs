using System.Collections.Generic;
using System.Threading.Tasks;
using TaskProject.Core.Models;

namespace TaskProject.Core.Database.Abstractions
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMovies();

        Task AddMovie(Movie movie);
    }
}