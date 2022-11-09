using Microsoft.AspNetCore.Mvc;
using MovieDB.Business.Providers.MovieDBApi;
using MovieDB.Business.Providers.MovieDBApi.Models.Request;
using MovieDB.Business.Providers.MovieDBApi.Models.Response;
using MovieDB.MVC.Models;
using System;

namespace MovieDB.MVC.Controllers
{
    public class MovieDetailController : Controller
    {
        public IActionResult Index(int id)
        {
            string language = "tr-TR";
            MovieDbMovieService movieService = new MovieDbMovieService();
            MovieDetail movieDetail = movieService.GetMovieDetail(new MovieDetailRequest
            {
                Language = language,
                MovieId = id
            }).Result;

            string productionCountries = "";
            int i = 0;
            while (movieDetail.production_countries.Count > i)
            {
                if (i > 0)
                    productionCountries += ", ";
                productionCountries += movieDetail.production_countries[i].iso_3166_1;
                i++;
            }

            string genres = "";
            i = 0;
            while (movieDetail.genres.Count > i)
            {
                if (i > 0)
                    genres += ", ";
                genres += movieDetail.genres[i].name;
                i++;
            }

            int movieHour = movieDetail.runtime / 60;
            int movieMinute = movieDetail.runtime - movieHour * 60;

            string movieYear = "-";
            if(DateTime.TryParse(movieDetail.release_date,out DateTime movieDateTime))
            {
                movieYear = movieDateTime.Year.ToString();
            }

            MovieDetailViewModel detailModel = new MovieDetailViewModel
            {
                Genres = genres,
                MovieRunTime = $"{movieHour}h {movieMinute}m",
                MovieTitle = movieDetail.title,
                MovieOriginalTitle = movieDetail.original_title,
                OverView = movieDetail.overview,
                ProductionCountries = productionCountries,
                RelaseDate = movieDetail.release_date,
                ReleaseYear = movieYear,
                TagLine = movieDetail.tagline,
                ImagePath=movieDetail.poster_path
            };

            SearchResponse<MovieHeader> similarList = movieService.GetMovieSimilar(new MovieSimilarRequest
            {
                Language = language,
                MovieId = id,
                Page = 1
            }).Result;

            var tupleModel = (detailModel, similarList);
            return View(tupleModel);
        }
    }
}
