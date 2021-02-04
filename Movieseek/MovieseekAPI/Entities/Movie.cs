using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieseekAPI.Entities
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Type { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }

    }
}
