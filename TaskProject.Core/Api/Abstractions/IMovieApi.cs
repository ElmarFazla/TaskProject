using System.Collections.Generic;
using System.Threading.Tasks;
using TaskProject.Core.Models;

namespace TaskProject.Core.Api.Abstractions
{
    public interface IMovieApi
    {
        //[Get("/s=star&type=movie&apikey=e7b0e27b")]
        Task<IEnumerable<Movie>> GetInitialMovies();

        Task<IEnumerable<Movie>> SearchMovies(string searchText);

        Task<MovieExtended> GetMovieDetails(string movieId);
    }
}