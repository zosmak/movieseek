using System.ComponentModel.DataAnnotations;

namespace MovieseekAPI.Models.Movies
{
    public class RegisterMovieModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Year { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int UserID { get; set; }
    }
}