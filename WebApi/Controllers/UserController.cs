using AutoMapper;
//using AutoMapper.Configuration;
using DataAccess.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Handlers.UserOperations.Commands.CreateUser;
using Microsoft.Extensions.Configuration;
using Core.TokenOperations.Models;
using Business.Handlers.UserOperations.Commands.CreateToken;
using Business.Handlers.UserOperations.Commands.RefreshToken;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        readonly IConfiguration _configuration; //appsettings.json içindeki verilere ulaşmayı sağlıyor
        public UserController(IBookStoreDbContext context,IConfiguration configuration,IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserModel newUser)
        {            
            CreateUserCommand command = new CreateUserCommand(_context,_mapper);
            command.Model = newUser;
            command.Handle();

            return Ok();
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_context, _mapper,_configuration);
            command.Model = login;
            var token = command.Handle();
            return token;

        }

        [HttpGet("refreshtoken")]
        public ActionResult<Token> RefreshToken([FromQuery] string token)
        {
            RefreshTokenCommand command = new RefreshTokenCommand(_context, _configuration);
            command.RefreshToken = token;
            var resultToken = command.Handle();
            return resultToken;

        }
    }
}
