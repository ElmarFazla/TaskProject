using System.Collections.Generic;
using System.Threading.Tasks;
using TaskProject.Core.Api.Dto;

namespace TaskProject.Core.Api.Abstractions
{
    public interface IMovieApi
    {
        //[Get("/s=star&type=movie&apikey=e7b0e27b")]
        Task<SearchResultDto> GetInitialMovies();

        Task<SearchResultDto> SearchMovies(string searchText);

        Task<MovieExtendedDto> GetMovieDetails(string movieId);
    }
}