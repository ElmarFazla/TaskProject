using System.Collections.Generic;

namespace TaskProject.Core.Models
{
    public class MovieExtended
    {
        public string Title { get; set; }

        public string Year { get; set; }

        public string Rated { get; set; }

        public string Runtime { get; set; }

        public string Genre { get; set; }

        public string Director { get; set; }

        public string Plot { get; set; }

        public string Poster { get; set; }

        public string ImdbRating { get; set; }

        public string ImdbID { get; set; }

        public IEnumerable<string> GenresList => Genre.Split(',');

        public string PosterUrl => Poster == "N/A" ? string.Empty : Poster;
    }
}