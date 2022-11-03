namespace MovieDB.Business.Providers.MovieDBApi.Models.Request
{
    public class SearchMovieRequest
    {
        public string Query { get; set; }
        public string Language { get; set; }
        public int Page { get; set; }
    }
}
