using DataAccess.Concrete.BookOperations.CreateBook;
using DataAccess.Concrete.BookOperations.DeleteBook;
using DataAccess.Concrete.BookOperations.GetBooks;
using DataAccess.Concrete.BookOperations.UpdateBook;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
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
            try
            {
                GetBookByIdQuery query = new GetBookByIdQuery(_context);
                query.Id = id;
                var result = query.Handle();
                return Ok(result);
            }
            catch (Exception E)
            {

                return BadRequest(E.Message);
            }          
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
            
            try
            {
                UpdateBookCommand command = new UpdateBookCommand(_context);
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

            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context)
                {
                    Id = id
                };

                command.Handle();
            }
            catch (Exception E)
            {

                return BadRequest(E.Message);
            }
         
            return Ok("Silindi");
        }

    }
}
