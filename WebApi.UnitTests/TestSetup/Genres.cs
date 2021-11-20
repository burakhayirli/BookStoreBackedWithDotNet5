using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.UnitTests.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this BookStoreContext context)
        {
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

        }
    }
}
