using MovieDB.Business.Providers.MovieDBApi.Models.Request;

namespace MovieDB.Business.Providers.MovieDBApi
{
    public static class MovieDBApiEndPoints
    {
        private static string SearchMovieBase => "http://api.themoviedb.org/3/search/movie/";
        public static string Movie => "https://api.themoviedb.org/3/movie";

        public static string SearchMovie(SearchMovieRequest request)
            => $"{SearchMovieBase}?{Parameters.ApiKeyKey}={Parameters.ApiKeyValue}&{Parameters.QueryKey}={Parameters.QueryValue(request.Query)}&{Parameters.languageKey}={request.Language}&{Parameters.PageKey}={request.Page}";

        public static string MovieDetail(MovieDetailRequest request)
            => $"{Movie}/{request.MovieId}?{Parameters.ApiKeyKey}={Parameters.ApiKeyValue}&{Parameters.languageKey}={request.Language}";

        public static string MovieSimilar(MovieSimilarRequest request)
            => $"{Movie}/{request.MovieId}/similar?{Parameters.ApiKeyKey}={Parameters.ApiKeyValue}&{Parameters.languageKey}={request.Language}&{Parameters.PageKey}={request.Page}";

        public static string MovieUpcoming(MovieUpComingRequest request)
            => $"{Movie}/upcoming?{Parameters.ApiKeyKey}={Parameters.ApiKeyValue}&{Parameters.languageKey}={request.Language}&{Parameters.PageKey}={request.Page}&{Parameters.RegionKey}={request.Region}";

    }

}
