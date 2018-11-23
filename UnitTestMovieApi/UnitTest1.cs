using MoviesApi.Controllers;
using MoviesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace UnitTestMovieApi
{
    [TestClass]
    public class UnitTest1
    {
        public static readonly DbContextOptions<MoviesApiContext> options
            = new DbContextOptionsBuilder<MoviesApiContext>()
                .UseInMemoryDatabase(databaseName: "testDatabase")
                .Options;

        private static readonly MovieItem Test1 = new MovieItem
        {
            Id = 1,
            Title = "Demo1",
            Year = "2015",
            Genre = "Action",
            PosterLink = "test1",
            DateCreated = "23/11/2018"
        };

        private static readonly MovieItem Test2 = new MovieItem
        {
            Id = 2,
            Title = "Demo2",
            Year = "2016",
            Genre = "Sci-Fi",
            PosterLink = "test2",
            DateCreated = "19/01/2018"
        };

        private static readonly MovieItem Test3 = new MovieItem
        {
            Id = 3,
            Title = "Demo3",
            Year = "2017",
            Genre = "Drama",
            PosterLink = "test3",
            DateCreated = "23/11/2008"
        };

        public static readonly IList<string> memeTitles = new List<string> { "movie1", "movie2" };

        [TestInitialize]
        public void SetupDb()
        {
            using (var context = new MoviesApiContext(options))
            {
                context.MovieItem.Add(Test1);
                context.MovieItem.Add(Test2);
                context.SaveChanges();
            }
        }

        [TestCleanup]
        public void ClearDb()
        {
            using (var context = new MoviesApiContext(options))
            {
                context.MovieItem.RemoveRange(context.MovieItem);
                context.SaveChanges();
            };
        }
        //private List<MovieItem> GetTestMovies()
        //{
        //    var testMovies = new List<MovieItem>
        //    {
        //        new MovieItem { Id = 1, Title = "Demo1", Year = "2015", Genre = "Action", PosterLink = "test1", DateCreated = "23/11/2018" },
        //        new MovieItem { Id = 2, Title = "Demo2", Year = "2016", Genre = "Sci-Fi", PosterLink = "test2", DateCreated = "19/01/2018" },
        //        new MovieItem { Id = 3, Title = "Demo3", Year = "2017", Genre = "Drama", PosterLink = "test3", DateCreated = "23/11/2008" },
        //        new MovieItem { Id = 4, Title = "Demo4", Year = "2018", Genre = "Thriller", PosterLink = "test4", DateCreated = "13/05/2018" }
        //    };

        //    return testMovies;
        //}

        //[TestMethod]
        //public async Task PutInsertsMovieItem()
        //{
        //    // Based on https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/in-memory
        //    var options = new DbContextOptionsBuilder<MoviesApiContext>()
        //        .UseInMemoryDatabase(databaseName: "testDB")
        //        .Options;

        //    using (var context = new MoviesApiContext(options))
        //    {
        //        var controller = new MovieController(context);
        //        IActionResult result = await controller.PutMovieItem(test1.Id, test1) as IActionResult;

        //        Assert.IsNotNull(result);
        //        Assert.IsInstanceOfType(result, typeof(NoContentResult));
        //        //Assert.AreEqual(1, context.MovieItem.Count());
        //        //Assert.AreEqual(test1.Title, context.MovieItem.Single().Title);
        //    }

        //}

        [TestMethod]
        public async Task PutMemeItemNoContentStatusCode()
        {
            using (var context = new MoviesApiContext(options))
            {
                // Given
                string title = "putMovie";
                MovieItem movieItem1 = context.MovieItem.Single(x => x.Title == Test1.Title);
                movieItem1.Title = title;

                // When
                MovieController movieController = new MovieController(context);
                IActionResult result = await movieController.PutMovieItem(movieItem1.Id, movieItem1) as IActionResult;

                // Then
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(NoContentResult));
            }
        }

        [TestMethod]
        public async Task PutMemeItemUpdate()
        {
            using (var context = new MoviesApiContext(options))
            {
                // Given
                string title = "putMovie";
                MovieItem movieItem1 = context.MovieItem.Single(x => x.Title == Test1.Title);
                movieItem1.Title = title;

                // When
                MovieController movieController = new MovieController(context);
                IActionResult result = await movieController.PutMovieItem(movieItem1.Id, movieItem1) as IActionResult;

                // Then
                MovieItem contextMovieItem1 = context.MovieItem.Single(x => x.Title == title);
                Assert.AreEqual(movieItem1, contextMovieItem1);
            }
        }

        [TestMethod]
        public void GetReturnsAllMovie()
        {
            using (var context = new MoviesApiContext(options))
            {
                // When
                MovieController movieController = new MovieController(context);
                var result = movieController.GetMovieItem();
                //IActionResult result2 = await movieController.PostMovieItem(Test2) as IActionResult;

                // Then
                Assert.IsNotNull(result);
                Assert.AreEqual(2, context.MovieItem.Count());
                //MovieItem contextMovieItem1 = context.MovieItem.Single(x => x.Title == Test1.Title);
                //Assert.AreEqual(Test1, contextMovieItem1);
                //MovieItem contextMovieItem2 = context.MovieItem.Single(x => x.Title == Test2.Title);
                //Assert.AreEqual(Test2, contextMovieItem2);
            }
        }

        [TestMethod]
        public async Task DeleteRemoveMovie()
        {
            using (var context = new MoviesApiContext(options))
            {
                // When
                MovieController movieController = new MovieController(context);
                IActionResult result = await movieController.DeleteMovieItem(Test1.Id) as IActionResult;
                //IActionResult result2 = await movieController.PostMovieItem(Test2) as IActionResult;

                // Then
                Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            }
        }

        [TestMethod]
        public async Task PostAddsNewMovie()
        {
            using (var context = new MoviesApiContext(options))
            {
                // When
                MovieController movieController = new MovieController(context);
                IActionResult result = await movieController.PostMovieItem(Test3) as IActionResult;
                //IActionResult result2 = await movieController.PostMovieItem(Test2) as IActionResult;

                // Then
                Assert.AreEqual(3, context.MovieItem.Count());

                //Assert.IsNotNull(result);
                MovieItem contextMovieItem1 = context.MovieItem.Single(x => x.Title == Test3.Title);
                Assert.IsNotNull(contextMovieItem1);
                //Assert.AreEqual(Test1, contextMovieItem1);
                //MovieItem contextMovieItem2 = context.MovieItem.Single(x => x.Title == Test2.Title);
                //Assert.AreEqual(Test2, contextMovieItem2);
            }
        }
    }
}