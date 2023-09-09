using MovieSorting;

namespace SortingComparisons_Test
{
    public class UnitTest1
    {
        [Fact]
        public void SortByYear_ShouldSortMoviesByYearDescending()
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie { Title = "Movie A", Year = 1990 },
                new Movie { Title = "Movie B", Year = 1985 },
                new Movie { Title = "Movie C", Year = 2000 }
            };

            List<Movie> sortedByYear = Sorting.SortByYear(movies);

            Assert.Equal(2000, sortedByYear[0].Year);
            Assert.Equal(1990, sortedByYear[1].Year);
            Assert.Equal(1985, sortedByYear[2].Year);
        }

        [Fact]
        public void SortByName_ShouldSortMoviesByNameIgnoringArticles()
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie { Title = "The Matrix", Year = 1999 },
                new Movie { Title = "Avatar", Year = 2009 },
                new Movie { Title = "Forrest Gump", Year = 1994 }
            };

            List<Movie> sortedByName = Sorting.SortByName(movies);

            Assert.Equal("Avatar", sortedByName[0].Title);
            Assert.Equal("Forrest Gump", sortedByName[1].Title);
            Assert.Equal("The Matrix", sortedByName[2].Title);
        }

    }
}