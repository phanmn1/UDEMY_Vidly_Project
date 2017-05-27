using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;

namespace Vidly.Controllers.api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context; 

        public MoviesController ()
        {
            _context = new ApplicationDbContext(); 
        }

        //GET /api/Movies
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies
                .Include(m=> m.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
        }

        //GET /api/Movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.id == id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        //POST /api/Movies/
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            //Maps MovieDto --> Movie returns movie type
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.id = movie.id;

            return Created((Request.RequestUri + "/" + movieDto.id), movieDto);
        } 

        //PUT /api/movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = _context.Movies.SingleOrDefault(m => m.id == id);
            if (movie == null)
                return NotFound();

            Mapper.Map(movieDto, movie);
            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/Movie/1 
        [HttpDelete]
        public IHttpActionResult DeleteMovie (int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.id == id);

            if (movie == null)
                return NotFound();

            _context.Movies.Remove(movie);

            return Ok();
        }


    }
}