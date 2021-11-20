using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.UnitTests.TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreContext context)
        {
            context.Books.AddRange(
                   new Book
                   {
                       Title = "Steve Jobs",
                       GenreId = 1,
                       PageCount = 550,
                       PublishDate = new DateTime(2021, 01, 21)
                   },
                    new Book
                    {
                        Title = "Bill Gates",
                        GenreId = 2,
                        PageCount = 220,
                        PublishDate = new DateTime(2000, 04, 05)
                    },
                    new Book
                    {
                        Title = "Sergey Brin",
                        GenreId = 2, // PersonalGrowth
                        PageCount = 430,
                        PublishDate = new DateTime(1998, 9, 4)
                    }
                );
        }
    }
}
