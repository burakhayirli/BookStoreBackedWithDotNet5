﻿using AutoMapper;
using Business.Handlers.BookOperations.CreateBook;
using Business.Handlers.BookOperations.DeleteBook;
using Business.Handlers.BookOperations.GetBooks;
using Business.Handlers.BookOperations.UpdateBook;
using DataAccess.Concrete.EntityFramework;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BooksController : ControllerBase
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;
        public BooksController(BookStoreContext context,IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            //var bookList = _context.Books.OrderBy(b => b.Id).ToList<Book>();
            //return bookList;

            GetBooksQuery query = new GetBooksQuery(_context,_mapper);
            var result =query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int  id)
        {
            try
            {
                GetBookByIdQuery query = new GetBookByIdQuery(_context,_mapper);
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

            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
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
