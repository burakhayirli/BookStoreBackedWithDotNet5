using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Handlers.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreContext _dbContext;
        public int Id { get; set; }
        public DeleteBookCommand(BookStoreContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Handle()
        {

            var book = _dbContext.Books.SingleOrDefault(b => b.Id == Id);
            if (book is null)
                new InvalidOperationException("Silinecek kitap bulunamadı");

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }

    }
}
