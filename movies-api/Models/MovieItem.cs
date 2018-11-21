using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi.Models
{
    public class MovieItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string PosterLink { get; set; }
        public string ImdbRating { get; set; }
        public string DateCreated { get; set; }
    }
}
