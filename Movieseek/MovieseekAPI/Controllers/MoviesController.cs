using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MovieseekAPI.Helpers;
using Microsoft.AspNetCore.Authorization;
using MovieseekAPI.Services;
using MovieseekAPI.Entities;
using MovieseekAPI.Models.Movies;

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
        /// <returns>Movies</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var movies = _movieService.GetAll();
            var model = _mapper.Map<IList<MovieModel>>(movies);
            return Ok(model);
        }

        [HttpPost]
        public IActionResult Register([FromBody] RegisterModel model)
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
                // create user
                _movieService.Create(movie);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var movie = _movieService.GetById(id);
            var model = _mapper.Map<MovieModel>(movie);
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateModel model)
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
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _movieService.Delete(id);
            return Ok();
        }
    }
}
