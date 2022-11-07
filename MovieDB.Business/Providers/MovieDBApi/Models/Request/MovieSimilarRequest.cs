namespace MovieDB.Business.Providers.MovieDBApi.Models.Request
{
    public class MovieSimilarRequest
    {
        public int MovieId { get; set; }
        public string Language { get; set; }
        public int Page { get; set; }
    }
}
