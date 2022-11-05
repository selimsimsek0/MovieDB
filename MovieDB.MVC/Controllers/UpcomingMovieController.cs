using Microsoft.AspNetCore.Mvc;
using MovieDB.Business.Providers.MovieDBApi;
using MovieDB.Business.Providers.MovieDBApi.Models.Request;
using MovieDB.Business.Providers.MovieDBApi.Models.Response;

namespace MovieDB.MVC.Controllers
{
    public class UpcomingMovieController : Controller
    {

        public IActionResult Index(int page=1)
        {
            if (page < 1) page = 1;
            MovieDbMovieService movieDbService = new MovieDbMovieService();
            MovieUpComingResponse response = movieDbService.GetMovieUpComing(new MovieUpComingRequest
            {

                Language = "tr-TR",
                Page = page,
                Region = "US"
            }).Result;
            
            return View(response);
        }
    }
}
