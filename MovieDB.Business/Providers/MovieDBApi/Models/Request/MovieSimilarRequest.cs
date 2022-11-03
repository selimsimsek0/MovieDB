namespace MovieDB.Business.Providers.MovieDBApi.Models.Request
{
    public class MovieSimilarRequest
    {
        public string MovieId { get; set; }
        public string Language { get; set; }
        public int Page { get; set; }
    }
}
