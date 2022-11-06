using Microsoft.AspNetCore.Mvc;
using MovieDB.Business.Providers.MovieDBApi;
using MovieDB.Business.Providers.MovieDBApi.Models.Request;
using MovieDB.Business.Providers.MovieDBApi.Models.Response;

namespace MovieDB.MVC.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult SearchMovie(string moviename,int page=1)
        {
            MovieDbSearchService searchService = new MovieDbSearchService();
            SearchResponse<MovieHeader> searchResponse = searchService.GetSearchMovieAsync(new SearchMovieRequest
            {
                Language = "tr-TR",
                Page = page,
                Query = moviename
            }).Result;

            var viewData = (searchResponse, moviename);

            ViewData["MovieName"] = moviename;
            return View(viewData);
        }
    }
}
