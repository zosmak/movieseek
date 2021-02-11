namespace Movieseek.Models.APIRequests
{
    public class AddMovieRequest
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Type { get; set; }
        public int UserID { get; set; }
    }
}
