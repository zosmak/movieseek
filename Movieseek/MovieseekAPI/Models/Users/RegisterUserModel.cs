using System.ComponentModel.DataAnnotations;

namespace MovieseekAPI.Models.Users
{
    public class RegisterUserModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}