﻿using MovieDB.Business.Providers.MovieDBApi.Models.Request;
using MovieDB.Business.Providers.MovieDBApi.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieDB.Business.Providers.MovieDBApi
{
    public class MovieDbSearchService
    {
        private HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.ConnectionClose = true;
            return client;
        }

        public async Task<SearchResponse<MovieHeader>> GetSearchMovieAsync(SearchMovieRequest request)
        {
            HttpClient client = GetHttpClient();
            Uri uri = new Uri(MovieDBApiEndPoints.SearchMovie(request));
            string responseString = await client.GetStringAsync(uri);
            SearchResponse<MovieHeader> response = JsonSerializer.Deserialize<SearchResponse<MovieHeader>>(responseString);

            return response;
        }
    }
}