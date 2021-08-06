using AutoMapper;
using DataAccess.Concrete.EntityFramework;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Handlers.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId { get; set; }
        private readonly BookStoreContext _dbContext;
        public DeleteGenreCommand(BookStoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre ==null)
            {
                throw new InvalidOperationException("Kitap türü bulunamadı!");
            }

            _dbContext.Genres.Remove(genre);
            _dbContext.SaveChanges();

        }
    }
}
