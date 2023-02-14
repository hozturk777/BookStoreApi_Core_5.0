using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WebApi;
using WebApiBookStore.Entities;

namespace WebApiBookStore.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookContext(serviceProvider.GetRequiredService<DbContextOptions<BookContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Authors.AddRange
                    (
                    new Author
                    {
                        Name = "Hüseyin",
                        SurName = "Öztürk",
                        DateOfBirth = 2001
                    },
                    new Author
                    {
                        Name = "Hasan",
                        SurName = "Seyrek",
                        DateOfBirth = 2001,
                    },
                    new Author
                    {
                        Name = "Recep",
                        SurName = "Tayyip",
                        DateOfBirth = 2001
                    },
                    new Author
                    {
                        Name = "Emircan",
                        SurName = "Bayendur",
                        DateOfBirth = 2001
                    }
                    );

                context.Genres.AddRange
                (
                    new Genre
                    {
                        GenreName = "Personel Growth"
                    },
                    new Genre
                    {
                        GenreName = "Science Fiction"
                    },
                    new Genre
                    {
                        GenreName = "Romance"
                    }
                 );
                context.Books.AddRange
                 (

                    new Book
                    {
                        //Id = 1,
                        Title = "Bukre",
                        GenreId = 1, //Personel Growth
                        PageCount = 200,
                        PublishDate = new DateTime(2005, 05, 20)
                    },
                    new Book
                    {
                        //Id = 2,
                        Title = "Bukre 2",
                        GenreId = 1, //Personel Growth
                        PageCount = 250,
                        PublishDate = new DateTime(2006, 06, 20)
                    }
                 );

                context.SaveChanges();
            }
        }
    }
}
