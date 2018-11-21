﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesApi.Models;

namespace MoviesApi.Migrations
{
    [DbContext(typeof(MoviesApiContext))]
    [Migration("20181121230306_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("MoviesApi.Models.MovieItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Country");

                    b.Property<string>("DateCreated");

                    b.Property<string>("Director");

                    b.Property<string>("Genre");

                    b.Property<string>("ImdbRating");

                    b.Property<string>("Language");

                    b.Property<string>("Plot");

                    b.Property<string>("PosterLink");

                    b.Property<string>("Runtime");

                    b.Property<string>("Title");

                    b.Property<string>("Year");

                    b.HasKey("Id");

                    b.ToTable("MovieItem");
                });
#pragma warning restore 612, 618
        }
    }
}