namespace Domain
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseYear { get; set; }

        public Movie(int id, string title, string director, DateTime releaseYear)
        {
            Id = id;
            Title = title;
            Director = director;
            ReleaseYear = releaseYear;
        }

        public override string ToString()
        {
            return ($"Id: {Id}, Title: {Title}, Director: {Director}, ReleaseYear: {ReleaseYear}");
        }

    }
}
