namespace MovieseekAPI.Models.Movies
{
    public class MovieModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Type { get; set; }
        public int UserID { get; set; }
    }
}