using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TaskProject.Core.Api.Abstractions;
using TaskProject.Core.Api.Dto;
using TaskProject.Core.Api.Mappers;
using TaskProject.Core.Models;

namespace TaskProject.Core.Api
{
    public class MovieApi : IMovieApi
    {
        HttpClient client;

        public MovieApi()
        {
            client = new HttpClient();
        }

        public async Task<IEnumerable<Movie>> GetInitialMovies()
        {
            return await SearchMovies("star");
        }

        public async Task<IEnumerable<Movie>> SearchMovies(string searchText)
        {
            if (string.IsNullOrEmpty(searchText) || searchText.Length < 4)
            {
                return new List<Movie>();
            }

            var urlString = $"https://www.omdbapi.com/?s={searchText}&apikey=e7b0e27b";

            Uri uri = new Uri(string.Format(urlString, string.Empty));

            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var moviesDtos = JsonConvert.DeserializeObject<SearchResultDto>(content);
                return moviesDtos.ToMoviesList();
            }

            return new List<Movie>();
        }

        public async Task<MovieExtended> GetMovieDetails(string movieId)
        {
            var urlString = $"https://www.omdbapi.com/?i={movieId}&apikey=e7b0e27b";

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
    }
}