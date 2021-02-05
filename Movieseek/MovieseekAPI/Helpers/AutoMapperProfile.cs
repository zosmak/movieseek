using AutoMapper;
using MovieseekAPI.Entities;
using MovieseekAPI.Models.Movies;
using MovieseekAPI.Models.Users;

namespace MovieseekAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // user
            CreateMap<User, UserModel>();
            CreateMap<RegisterUserModel, User>();
            CreateMap<UpdateUserModel, User>();

            // movie
            CreateMap<Movie, MovieModel>();
            CreateMap<RegisterMovieModel, Movie>();
            CreateMap<UpdateMovieModel, Movie>();
        }
    }
}