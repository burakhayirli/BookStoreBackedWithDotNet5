using AutoMapper;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Handlers.BookOperations.CreateBook
{
   public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly BookStoreContext _dbContext;
        private readonly IMapper _mapper;

        public CreateBookCommand(BookStoreContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(b => b.Title == Model.Title);
            if (book!=null)
                throw new InvalidOperationException("Kitap zaten mevcut");

            book = _mapper.Map<Book>(Model);

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }       
    }
}
