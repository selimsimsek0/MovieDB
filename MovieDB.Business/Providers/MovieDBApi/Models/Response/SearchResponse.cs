using System.Collections.Generic;

namespace MovieDB.Business.Providers.MovieDBApi.Models.Response
{
    public class SearchResponse<T>
    {
        public int page { get; set; }
        public IEnumerable<T> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}
