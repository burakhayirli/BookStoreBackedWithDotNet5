using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Handlers.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookModel Model { get; set; }
        public int Id { get; set; }
        private readonly IBookStoreDbContext _dbContext;

        public UpdateBookCommand(IBookStoreDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == this.Id);

            if (book is null) 
                throw new InvalidOperationException("Boş veri gönderilemez. Lütfen verdiğiniz bilgileri kontrol ediniz.");

            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
          //  book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
            book.Title = Model.Title != default ? Model.Title : book.Title;
            //book.PublishDate = Model.PublishDate != default ? Convert.ToDateTime(Model.PublishDate) : book.PublishDate;
            _dbContext.SaveChanges();
        }
    }    
}
