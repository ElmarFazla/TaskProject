using System.Collections.Generic;
using System.Threading.Tasks;
using TaskProject.Core.Models;

namespace TaskProject.Core.Services.Abstractions
{
    public interface IMovieApiManager
    {
        Task<IEnumerable<Movie>> GetInitialMovies();

        Task<IEnumerable<Movie>> SearchMovies(string searchText);

        Task<MovieExtended> GetMovieDetails(string movieId);
    }
}