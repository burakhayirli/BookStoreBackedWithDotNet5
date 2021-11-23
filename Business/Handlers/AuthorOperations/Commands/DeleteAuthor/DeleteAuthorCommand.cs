
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Handlers.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly IBookStoreDbContext _dbContext;
        public int Id { get; set; }
        public DeleteAuthorCommand(IBookStoreDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void Handle()
        {

            var author = _dbContext.Authors.SingleOrDefault(b => b.Id == Id);
            if (author is null)
                throw new InvalidOperationException("Silinecek yazar bulunamadı");

            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();
        }
    }
}
