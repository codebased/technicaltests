using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBA.Movie.WebApi.Core.Controllers
{
    public class SearchMovie
    {
        public int? ID { get; set; }
        public string Classification { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int? Rating { get; set; }
        public string Cast { get; set; }
        public int? ReleaseDate { get; set; }
    }
}
