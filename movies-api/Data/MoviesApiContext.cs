using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MoviesApi.Models
{
    public class MoviesApiContext : DbContext
    {
        public MoviesApiContext (DbContextOptions<MoviesApiContext> options)
            : base(options)
        {
        }

        public DbSet<MoviesApi.Models.MovieItem> MovieItem { get; set; }
    }
}
