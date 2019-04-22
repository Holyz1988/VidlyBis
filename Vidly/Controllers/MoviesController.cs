using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        /// <summary>
        /// Renvoi la liste des films 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            // ->On récupère les clients
            IList<Movie> movies = GetMovies();

            // ->On test si l'objet client est null
            if (movies == null)
                return new HttpNotFoundResult();

            // -> Retour de fonction
            return View(movies);
        }

        /// <summary>
        /// Renvoi le detail d'un client
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [Route("movies/details/{movieId}")]
        public ActionResult Details(int? movieId)
        {
            // ->Test si l'identifiant du client existe
            if (!movieId.HasValue)
                return new HttpNotFoundResult();

            // -> On récupère le client qui possède le bon identifiant
            IList<Movie> movies = GetMovies();
            Movie movie = movies.Where(m => m.Id == movieId)
                                .SingleOrDefault();

            // -> On test si l'objet est null
            if (movie == null)
                return new HttpNotFoundResult();

            // ->Retour de fonction
            return View(movie);
        }

        /// <summary>
        /// Récupère la liste des films
        /// </summary>
        /// <returns></returns>
        private IList<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Name = "Shrek", Id = 1},
                new Movie { Name = "Narnia", Id = 2},
                new Movie { Name = "Matrix", Id = 3},
            };
        }

        // GET: Movies/Random
        //public ActionResult Random()
        //{
        //    Movie movie = new Movie() { Name = "Shrek!" };

        //    //ViewData["Movie"] = movie;

        //    //ViewBag.Movie = movie;

        //    List<Customer> customers = new List<Customer>
        //    {
        //        new Customer { FirstName = "Amine" },
        //        new Customer { FirstName = "Nadia" }
        //    };

        //    RandomMovieViewModel viewModel = new RandomMovieViewModel
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };

        //    return View(viewModel);
        //}



        //// GET: Movies/Random
        //public ActionResult Random()
        //{
        //    Movie movie = new Movie() { Name = "Shrek!" };

        //    return View(movie);


        //    //return Content("Hello World");
        //    //return HttpNotFound();
        //    //return new EmptyResult();
        //    //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name"});
        //}



        //[Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}

        //public ActionResult Edit(int id)
        //{
        //    return Content("id = " + id);
        //}

        // movies
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (string.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}
    }
}