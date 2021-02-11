using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MovieseekAPI.Helpers;
using Microsoft.AspNetCore.Authorization;
using MovieseekAPI.Services;
using MovieseekAPI.Entities;
using MovieseekAPI.Models.Movies;
using System;

namespace MovieseekAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MoviesController(
            IMovieService movieService,
            IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all movies
        /// </summary>
        /// <response code="201">Returns the movies</response>
        /// <response code="401">Unauthorized</response>            
        [HttpGet]
        public IActionResult GetAll()
        {
            var movies = _movieService.GetAll();
            var model = _mapper.Map<IList<MovieModel>>(movies);
            return Ok(model);
        }

        /// <summary>
        /// Get a movie by id
        /// </summary>
        /// <response code="200">Returns the movie</response>
        /// <response code="401">Unauthorized</response>            
        /// <response code="404">Movie wasn't found</response>            
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var movie = _movieService.GetById(id);
            if (movie != null)
            {
                var model = _mapper.Map<MovieModel>(movie);
                return Ok(model);
            }
            return NotFound();
        }

        /// <summary>
        /// Creates a movie
        /// </summary>
        /// <response code="201">Returns the created movie</response>
        /// <response code="400">Bad request</response>            
        /// <response code="401">Unauthorized</response>            
        [HttpPost]
        public IActionResult Create([FromBody] RegisterMovieModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("error", "invalid request body");
                return BadRequest(ModelState);
            }

            // map model to entity
            var movie = _mapper.Map<Movie>(model);

            try
            {
                // create movie
                var savedMovie = _movieService.Create(movie);
                return Ok(savedMovie);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Updates a movie
        /// </summary>
        /// <response code="200">Returns the updated movie</response>
        /// <response code="400">Bad request</response>            
        /// <response code="401">Unauthorized</response>            
        /// <response code="404">Movie wasn't found</response>            
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateMovieModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("error", "invalid request body");
                return BadRequest(ModelState);
            }

            // map model to entity and set id
            var movie = _mapper.Map<Movie>(model);
            movie.ID = id;

            try
            {
                // update movie 
                _movieService.Update(movie);
                var updatedMovie = _movieService.GetById(id);
                return Ok(updatedMovie);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Deletes a movie
        /// </summary>
        /// <response code="204"></response>
        /// <response code="401">Unauthorized</response>            
        /// <response code="404">Movie wasn't found</response>            
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = _movieService.GetById(id);
            if (movie != null)
            {
                _movieService.Delete(id);
                return NoContent();
            }

            return NotFound();
        }
    }
}
