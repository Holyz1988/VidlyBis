using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

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
            IEnumerable<Movie> movies = _context.Movies.Include(m => m.Genre).ToList();

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
            Movie movie = _context.Movies.Include(m => m.Genre)
                                         .SingleOrDefault(m => m.Id == movieId);

            // -> On test si l'objet est null
            if (movie == null)
                return new HttpNotFoundResult();

            // ->Retour de fonction
            return View(movie);
        }
    }
}