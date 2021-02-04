using AutoMapper;
using MovieseekAPI.Entities;

namespace MovieseekAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // user
            CreateMap<User, Models.Users.UserModel>();
            CreateMap<Models.Users.RegisterModel, User>();
            CreateMap<Models.Users.UpdateModel, User>();

            // movie
            CreateMap<Movie, Models.Movies.MovieModel>();
            CreateMap<Models.Movies.RegisterModel, Movie>();
            CreateMap<Models.Movies.UpdateModel, Movie>();
        }
    }
}