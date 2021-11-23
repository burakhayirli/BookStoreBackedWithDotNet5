using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreContext>>()))
            {

                if (context.Books.Any())
                {
                    return;
                }

                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personel Growth"
                    },
                    new Genre
                    {
                        Name = "Science Fiction"
                    },
                    new Genre
                    {
                        Name = "Romance"
                    }
                    );


                context.Authors.AddRange(
                    new Author { Id=1, Name="Steve", Surname="Jobs"},
                    new Author { Id = 2, Name ="Bill", Surname="Gates"},
                    new Author { Id = 3, Name ="Sergey", Surname="Brin"}
                    );

                context.Books.AddRange(
                   new Book
                   {
                       Title = "Steve Jobs Book",
                       GenreId = 1,
                       PageCount = 550,
                       PublishDate = new DateTime(2021, 01, 21),
                       AuthorId=1

                   },
                    new Book
                    {
                        Title = "Bill Gates Book",
                        GenreId = 2,
                        PageCount = 220,
                        PublishDate = new DateTime(2000, 04, 05),
                        AuthorId = 2
                    },
                    new Book
                    {
                        Title = "Sergey Brin Book",
                        GenreId = 2, // PersonalGrowth
                        PageCount = 430,
                        PublishDate = new DateTime(1998, 9, 4),
                        AuthorId = 3
                    }
                   );

                context.SaveChanges();
            }
        }
    }
}
