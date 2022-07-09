using System.Collections.Generic;
using System.Threading.Tasks;
using TaskProject.Core.Api.Abstractions;
using TaskProject.Core.Api.Mappers;
using TaskProject.Core.Models;
using TaskProject.Core.Services.Abstractions;

namespace TaskProject.Core.Services
{
    public class MovieApiManager : IMovieApiManager
    {
        private readonly IMovieApi _movieApi;

        public MovieApiManager(IMovieApi movieApi)
        {
            _movieApi = movieApi;
        }

        public async Task<IEnumerable<Movie>> GetInitialMovies()
        {
            var searchResultDto = await _movieApi.GetInitialMovies();

            return searchResultDto.ToMoviesList();
        }

        public async Task<IEnumerable<Movie>> SearchMovies(string searchText)
        {
            var searchResultDto = await _movieApi.SearchMovies(searchText);

            return searchResultDto.ToMoviesList();
        }

        public async Task<MovieExtended> GetMovieDetails(string movieId)
        {
            var movieExtendedDto = await _movieApi.GetMovieDetails(movieId);

            return movieExtendedDto.ToMovieExtended();
        }
    }
}