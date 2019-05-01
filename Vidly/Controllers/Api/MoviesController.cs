using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Vidly.Dtos;
using Vidly.Models;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
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

        /// GET /api/movies
        /// <summary>
        /// Recupère la liste de tous les films
        /// </summary>
        /// <returns>Liste de films</returns>
        public IHttpActionResult GetMovies()
        {
            IEnumerable<MovieDto> moviesDto = _context.Movies
                .Include(m => m.Genre)
                .ToList().Select(Mapper.Map<Movie, MovieDto>);

            return Ok(moviesDto);
        }

        /// GET /api/movies/{id}
        /// <summary>
        /// API pour récupérer un film en fonction de son identifiant
        /// </summary>
        /// <param name="id">identifiant du film</param>
        /// <returns>Le film</returns>
        public IHttpActionResult GetMovie(int id)
        {
            Movie movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            MovieDto movieDto = Mapper.Map<Movie, MovieDto>(movie);

            return Ok(movieDto);
        }

        /// POST /api/movies/
        /// <summary>
        /// API pour la création d'un film
        /// </summary>
        /// <param name="movie">Film à créer</param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            // => On vérifie la validité du modèle
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Movie movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        // PUT /api/movies/1
        /// <summary>
        /// API Pour mettre à jour un film
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movie"></param>
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            Movie movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

            return Ok();
        }

        /// DELETE api/movies/{id}
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            Movie movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return BadRequest();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
