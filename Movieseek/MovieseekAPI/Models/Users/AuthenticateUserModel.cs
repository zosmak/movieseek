using System.ComponentModel.DataAnnotations;

namespace MovieseekAPI.Models.Users
{
    public class AuthenticateUserModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}