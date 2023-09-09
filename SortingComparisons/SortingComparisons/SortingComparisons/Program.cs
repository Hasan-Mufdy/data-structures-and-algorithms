using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieSorting
{
    public class Program
    {
        static void Main()
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie
                {
                    Title = "The Lion King",
                    Year = 1994,
                    Genres = new List<string> { "Animation", "Adventure", "Family" }
                },
                new Movie
                {
                    Title = "Toy Story",
                    Year = 1995,
                    Genres = new List<string> { "Animation", "Adventure", "Comedy" }
                },
                new Movie
                {
                    Title = "The Lord of the Rings",
                    Year = 2001,
                    Genres = new List<string> { "Fantasy", "Adventure", "Action" }
                },
                new Movie
                {
                    Title = "Blade Runner",
                    Year = 1982,
                    Genres = new List<string> { "Sci-Fi", "Action" }
                },
                new Movie
                {
                    Title = "Saving Private Ryan",
                    Year = 1998,
                    Genres = new List<string> { "Drama", "War" }
                },
                new Movie
                {
                    Title = "Scream",
                    Year = 1996,
                    Genres = new List<string> { "Horror", "Mystery" }
                },
                new Movie
                {
                    Title = "The Departed",
                    Year = 2006,
                    Genres = new List<string> { "Crime", "Thriller", "Drama" }
                },
                new Movie
                {
                    Title = "The Incredibles",
                    Year = 2004,
                    Genres = new List<string> { "Animation", "Action" }
                },
                new Movie
                {
                    Title = "Avatar",
                    Year = 2009,
                    Genres = new List<string> { "Action", "Adventure", "Fantasy" }
                },
                new Movie
                {
                    Title = "The Matrix",
                    Year = 1999,
                    Genres = new List<string> { "Action", "Sci-Fi" }
                },
                new Movie
                {
                    Title = "Forrest Gump",
                    Year = 1994,
                    Genres = new List<string> { "Drama", "Romance" }
                },
            };

            List<Movie> sortedByYear = Sorting.SortByYear(movies);
            List<Movie> sortedByTitle = Sorting.SortByName(movies);

            Console.WriteLine("{0,-30} {1}", "Title", "Year");
            Console.WriteLine(new string('-', 36));

            foreach (var movie in sortedByYear)
            {
                Console.WriteLine("{0,-30} {1}", movie.Title, movie.Year);
            }

            Console.WriteLine("\nSorted by title (ignoring articles):");
            foreach (var movie in sortedByTitle)
            {
                Console.WriteLine($"Title: {movie.Title}");
            }
        }
    }

    public class Sorting
    {
        public static List<Movie> SortByName(List<Movie> movies)
        {
            string[] skipWords = { "The", "An", "A" };

            return movies.OrderBy(movie => RemoveLeadingArticles(movie.Title, skipWords)).ToList();
        }

        public static List<Movie> SortByYear(List<Movie> movies)
        {
            return movies.OrderByDescending(movie => movie.Year).ToList();
        }

        private static string RemoveLeadingArticles(string title, string[] skipWords)
        {
            foreach (var word in skipWords)
            {
                if (title.StartsWith(word + " ", StringComparison.OrdinalIgnoreCase))
                {
                    title = title.Substring(word.Length).TrimStart();
                }
            }
            return title;
        }
    }

    public class Movie
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public List<string> Genres { get; set; }
    }
}
