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
            HttpClient client = GetHttpClient();
            Uri uri = new Uri(MovieDBApiEndPoints.MovieDetail(request));
            string responseString = await client.GetStringAsync(uri);
            MovieDetail response = JsonConvert.DeserializeObject<MovieDetail>(responseString);
            return response;
        }

        public async Task<SearchResponse<MovieHeader>> GetMovieSimilar(MovieSimilarRequest request)
        {
            HttpClient client = GetHttpClient();
            Uri uri = new Uri(MovieDBApiEndPoints.MovieSimilar(request));
            string responseString = await client.GetStringAsync(uri);
            SearchResponse<MovieHeader> response = JsonConvert.DeserializeObject<SearchResponse<MovieHeader>>(responseString);
            return response;
        }

        public async Task<MovieUpComingResponse> GetMovieUpComing(MovieUpComingRequest request)
        {
            HttpClient client = GetHttpClient();
            Uri uri = new Uri(MovieDBApiEndPoints.MovieUpcoming(request));
            string responseString = await client.GetStringAsync(uri);
            MovieUpComingResponse response = JsonConvert.DeserializeObject<MovieUpComingResponse>(responseString);
            return response;
        }

    }
}
