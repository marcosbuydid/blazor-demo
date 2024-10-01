﻿namespace Domain
{
    public class Movie
    {
        private string title;
        private string director;
        private DateTime releaseDate;
        private int budget;

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Title cannot be null or empty");
                }
                title = value;
            }
        }
        public string Director
        {
            get
            {
                return director;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Director cannot be null or empty");
                }
                director = value;
            }

        }
        public DateTime ReleaseDate { get; set; }
        public int Budget
        {
            get
            {
                return budget;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("The budget of the movie must be a positive number");
                }
                budget = value;
            }
        }

        public Movie(string title, string director, DateTime releaseYear, int budget)
        {
            Title = title;
            Director = director;
            ReleaseDate = releaseYear;
            Budget = budget;
        }

        public override string ToString()
        {
            return $"Title: {Title}, Director: {Director}, ReleaseYear: {ReleaseDate}";
        }

    }
}
