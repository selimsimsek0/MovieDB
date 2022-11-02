using System.Collections.Generic;

namespace MovieDB.Business.Providers.MovieDBApi.Models.Response
{
    public class MovieUpComingResponse
    {
        public Dates dates { get; set; }
        public int page { get; set; }
        public List<MovieHeader> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}
