using System.Collections.Generic;
using System.Linq;
using TaskProject.Core.Api.Dto;
using TaskProject.Core.Models;

namespace TaskProject.Core.Api.Mappers
{
    public static class Mappers
    {
        public static Movie ToMovie(this MovieDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new Movie
            {
                Title = dto.Title,
                Year = dto.Year,
                Poster = dto.Poster,
                ImdbID = dto.ImdbID
            };
        }

        public static IEnumerable<Movie> ToMoviesList(this SearchResultDto dtos)
        {
            if (dtos == null)
            {
                return null;
            }

            return dtos.Search.Select(x => x.ToMovie());
        }

        public static MovieExtended ToMovieExtended(this MovieExtendedDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new MovieExtended
            {
                Title = dto.Title,
                Year = dto.Year,
                Poster = dto.Poster,
                Director = dto.Director,
                Genre = dto.Genre,
                ImdbRating = dto.ImdbRating,
                ImdbID = dto.ImdbID,
                Plot = dto.Plot,
                Rated = dto.Rated,
                Runtime = dto.Runtime
            };
        }
    }
}