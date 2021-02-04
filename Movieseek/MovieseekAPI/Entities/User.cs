using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieseekAPI.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<Movie> Movies { get; set; }

    }
}
