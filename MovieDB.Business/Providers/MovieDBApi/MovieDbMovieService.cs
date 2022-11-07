using MovieDB.Business.Providers.MovieDBApi.Models.Request;
using MovieDB.Business.Providers.MovieDBApi.Models.Response;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieDB.Business.Providers.MovieDBApi
{
    public class MovieDbMovieService
    {
        private HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.ConnectionClose = true;
            return client;
        }

        public async Task<MovieDetail> GetMovieDetail(MovieDetailRequest request)
        {
            MovieDetail detail = new MovieDetail();
            try
            {
                HttpClient client = GetHttpClient();
                Uri uri = new Uri(MovieDBApiEndPoints.MovieDetail(request));
                string responseString = await client.GetStringAsync(uri);
                MovieDetail response = JsonConvert.DeserializeObject<MovieDetail>(responseString);
                detail = response;

            }
            catch
            {
            }

            return detail;

        }

        public async Task<SearchResponse<MovieHeader>> GetMovieSimilar(MovieSimilarRequest request)
        {
            SearchResponse<MovieHeader> searchResponse = new SearchResponse<MovieHeader>();
            try
            {
                HttpClient client = GetHttpClient();
                Uri uri = new Uri(MovieDBApiEndPoints.MovieSimilar(request));
                string responseString = await client.GetStringAsync(uri);
                SearchResponse<MovieHeader> response = JsonConvert.DeserializeObject<SearchResponse<MovieHeader>>(responseString);
                searchResponse = response;
            }
            catch
            {
            }
            return searchResponse;
        }

        public async Task<MovieUpComingResponse> GetMovieUpComing(MovieUpComingRequest request)
        {
            MovieUpComingResponse movieUpComingResponse = new();
            try
            {
                HttpClient client = GetHttpClient();
                Uri uri = new Uri(MovieDBApiEndPoints.MovieUpcoming(request));
                string responseString = await client.GetStringAsync(uri);
                MovieUpComingResponse response = JsonConvert.DeserializeObject<MovieUpComingResponse>(responseString);
                movieUpComingResponse = response;
            }
            catch
            {
            }
            return movieUpComingResponse;

        }

    }
}
