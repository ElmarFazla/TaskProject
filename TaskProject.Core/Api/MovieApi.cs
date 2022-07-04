using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TaskProject.Core.Api.Abstractions;
using TaskProject.Core.Api.Dto;
using TaskProject.Core.Api.Mappers;
using TaskProject.Core.Models;
using TaskProject.Core.Services.Abstractions;

namespace TaskProject.Core.Api
{
    public class MovieApi : IMovieApi
    {
        HttpClient client;
        private readonly IAuthService _authService;
        private readonly string _apiKey;

        public MovieApi(IAuthService authService)
        {
            _authService = authService;
            client = new HttpClient();
        }

        // Since the API doesn't contain an call to give random or TOP10 movies,
        // I had to simulate the call with a search so that the initial call has some movies to show
        public async Task<IEnumerable<Movie>> GetInitialMovies()
        {
            return await SearchMovies("star");
        }

        public async Task<IEnumerable<Movie>> SearchMovies(string searchText)
        {
            var apiKey = await _authService.GetApiKey();

            if (string.IsNullOrEmpty(searchText) || searchText.Length < 4)
            {
                return new List<Movie>();
            }

            var urlString = $"https://www.omdbapi.com/?s={searchText}&apikey={apiKey}";

            Uri uri = new Uri(string.Format(urlString, string.Empty));

            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                if (SearchHasResults(content))
                {
                    var moviesDtos = JsonConvert.DeserializeObject<SearchResultDto>(content);
                    return moviesDtos.ToMoviesList();
                }
            }

            return new List<Movie>();
        }

        public async Task<MovieExtended> GetMovieDetails(string movieId)
        {
            var apiKey = await _authService.GetApiKey();

            var urlString = $"https://www.omdbapi.com/?i={movieId}&apikey={apiKey}";

            Uri uri = new Uri(string.Format(urlString, string.Empty));

            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var moviesExtendedDto = JsonConvert.DeserializeObject<MovieExtendedDto>(content);
                return moviesExtendedDto.ToMovieExtended();
            }

            return null;
        }

        // Usually response.IsSuccessStatusCode should be enogh to check if call was succesfull and API would return empty list for no results
        // but in this case with the Public API, it returns an error message with Code 200 which is wrong. I had to make sure the code doesn't break when this happends
        private bool SearchHasResults(string content)
        {
            if (content.Contains("Movie not found"))
            {
                return false;
            }

            return true;
        }
    }
}