using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using VidlyApp.DTOs;
using VidlyApp.Models;
using System.Data.Entity;

namespace VidlyApp.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        //GET /api/movies
        [HttpGet]
        public IHttpActionResult GetMovies()
        {
            var movieDtos = _context.Movies.Include(m => m.Gendre).ToList().Select(Mapper.Map<Movie, MovieDto>);
            
            return Ok(movieDtos);
        }

        //GET /api/movies/1
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
           // var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            var movieDto = _context.Movies.Select(Mapper.Map<Movie, MovieDto>).SingleOrDefault(m => m.Id == id);
            if (movieDto == null)
                return NotFound();

            return Ok(movieDto);
        }


        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = Mapper.Map<MovieDto,Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
            {
                return NotFound();
            }
            Mapper.Map<MovieDto,Movie>(movieDto,movieInDb);
            
            _context.SaveChanges();
            return Ok(movieInDb);
        }

        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return Ok(movie);


        }


    }
}
