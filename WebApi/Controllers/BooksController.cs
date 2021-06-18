using DataAccess.Concrete.BookOperations.CreateBook;
using DataAccess.Concrete.BookOperations.GetBooks;
using DataAccess.Concrete.BookOperations.UpdateBook;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DataAccess.Concrete.BookOperations.CreateBook.CreateBookCommand;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreContext _context;
        public BooksController(BookStoreContext context)
        {
            this._context = context;
        }

        //private static List<Book> BookList = new List<Book>() { 
        //    new Book
        //    {
        //        Id=1,
        //        Title="Steve Jobs",
        //        GenreId=1, // PersonalGrowth
        //        PageCount=550,
        //        PublishDate= new DateTime(2021,01,21)
        //    },
        //    new Book
        //    {
        //        Id=2,
        //        Title="Bill Gates",
        //        GenreId=3, // PersonalGrowth
        //        PageCount=220,
        //        PublishDate= new DateTime(2000,04,05)
        //    },
        //    new Book
        //    {
        //        Id=3,
        //        Title="Sergey Brin",
        //        GenreId=5, // PersonalGrowth
        //        PageCount=430,
        //        PublishDate= new DateTime(1998,9,4)
        //    },
        //};

        [HttpGet]
        public IActionResult GetBooks()
        {
            //var bookList = _context.Books.OrderBy(b => b.Id).ToList<Book>();
            //return bookList;

            GetBooksQuery query = new GetBooksQuery(_context);
            var result =query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int  id)
        {
            GetBookByIdQuery query = new GetBookByIdQuery(_context);
            query.Id = id;
            var result = query.Handle();
            
            return Ok(result);
        }

        
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {

            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch (Exception E)
            {
                return BadRequest(E.Message);
            }

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook) {
            UpdateBookCommand command = new UpdateBookCommand(_context);

            try
            {
                command.Id = id;
                command.Model = updatedBook;
                command.Handle();
            }
            catch (Exception E)
            {
                return BadRequest(E.Message);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if (book is null)
                return BadRequest("Silinemedi");
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok("Silindi");
        }

    }
}
