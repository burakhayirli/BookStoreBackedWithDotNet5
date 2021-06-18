using DataAccess.Concrete.EntityFramework;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.BookOperations.GetBooks
{
    public class GetBookByIdQuery
    {
        public int Id { get; set; }
        private readonly BookStoreContext _dbContext;

        public GetBookByIdQuery(BookStoreContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public BooksViewModel Handle()
        {
            var book = _dbContext.Books.Where(book => book.Id == this.Id).SingleOrDefault();
            BooksViewModel vm = new BooksViewModel()
            {
                Title = book.Title,
                PageCount = book.PageCount,
                Genre = ((GenreEnum)book.GenreId).ToString(),
                PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy")
            };
            return vm;
        }
    }



}
