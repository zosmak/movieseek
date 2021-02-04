using System;
using System.Collections.Generic;
using System.Linq;
using MovieseekAPI.Entities;
using MovieseekAPI.Helpers;

namespace MovieseekAPI.Services
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
        Movie Create(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
    }

    public class MovieService : IMovieService
    {
        private readonly DataContext _context;

        public MovieService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetAll()
        {
            return _context.Movies;
        }

        public Movie GetById(int id)
        {
            return _context.Movies.Find(id);
        }

        public Movie Create(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return movie;
        }

        public void Update(Movie movieParam)
        {
            Movie movie = _context.Movies.Find(movieParam.ID);

            if (movie == null)
                throw new AppException("Movie not found");

            // update movie properties if provided
            if (!string.IsNullOrWhiteSpace(movieParam.Title))
                movie.Title = movieParam.Title;

            if (!string.IsNullOrWhiteSpace(movieParam.Type))
                movie.Type = movieParam.Type;

            if (!string.IsNullOrWhiteSpace(movieParam.Year))
                movie.Year = movieParam.Year;

            _context.Movies.Update(movie);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
        }
    }
}