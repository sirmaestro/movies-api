using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MoviesApi.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MoviesApiContext(
                serviceProvider.GetRequiredService<DbContextOptions<MoviesApiContext>>()))
            {
                // Look for any movies.
                if (context.MovieItem.Count() > 0)
                {
                    return;   // DB has been seeded
                }

                context.MovieItem.AddRange(
                    new MovieItem
                    {
                        Title = "Avengers: Infinity War",
                        Year = "2018",
                        Runtime = "149 min",
                        Genre = "Action, Adventure, Fantasy, Sci-Fi",
                        Director = "Anthony Russo, Joe Russo",
                        Plot = "The Avengers and their allies must be willing to sacrifice all in an attempt to defeat the powerful Thanos before his blitz of devastation and ruin puts an end to the universe.",
                        Language = "English",
                        Country = "USA",
                        PosterLink = "https://m.media-amazon.com/images/M/MV5BMjMxNjY2MDU1OV5BMl5BanBnXkFtZTgwNzY1MTUwNTM@._V1_SX300.jpg",
                        ImdbRating = "8.6"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
