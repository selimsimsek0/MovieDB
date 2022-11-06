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
            MovieDbMovieService movvieService = new MovieDbMovieService();
            MovieDetail movieDetail = movvieService.GetMovieDetail(new MovieDetailRequest
            {
                Language = "tr-TR",
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

            MovieDetailViewModel model = new MovieDetailViewModel
            {
                Genres = genres,
                MovieRunTime = $"{movieHour}h {movieMinute}m",
                MovieTitle = movieDetail.original_title,
                OverView = movieDetail.overview,
                ProductionCountries = productionCountries,
                RelaseDate = movieDetail.release_date,
                ReleaseYear = movieYear,
                TagLine = movieDetail.tagline,
                ImagePath=movieDetail.poster_path
            };

            return View(model);
        }
    }
}
