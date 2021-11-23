using AutoMapper;
using Business.Handlers.AuthorOperations.Commands.CreateAuthor;
using Business.Handlers.AuthorOperations.Commands.DeleteAuthor;
using Business.Handlers.AuthorOperations.Commands.UpdateAuthor;
using Business.Handlers.AuthorOperations.Queries.GetAuthors;
using Business.Handlers.BookOperations.GetBooks;
using DataAccess.Abstract;
using Entities.Dtos;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public AuthorsController(IBookStoreDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                GetAuthorsByIdQuery query = new GetAuthorsByIdQuery(_context, _mapper);
                query.Id = id;

                GetAuthorsByIdQueryValidator validator = new GetAuthorsByIdQueryValidator();
                validator.ValidateAndThrow(query);
                var result = query.Handle();
                return Ok(result);
            }
            catch (Exception E)
            {
                return BadRequest(E.Message);
            }
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            command.Model = newAuthor;
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel updatedAuthor)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context)
            {
                Id = id,
                Model = updatedAuthor
            };

            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context)
            {
                Id = id
            };

            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok("Silindi");
        }

    }
}
