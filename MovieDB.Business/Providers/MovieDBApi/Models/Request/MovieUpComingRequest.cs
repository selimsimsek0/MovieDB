namespace MovieDB.Business.Providers.MovieDBApi.Models.Request
{
    public class MovieUpComingRequest 
    {
        public string Language { get; set; }
        public int Page { get; set; }
        public string Region { get; set; }
    }
}
