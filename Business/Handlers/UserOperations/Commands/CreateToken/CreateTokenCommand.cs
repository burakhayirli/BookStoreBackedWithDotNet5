using AutoMapper;
using Core.TokenOperations;
using Core.TokenOperations.Models;
using DataAccess.Abstract;
using Entities.Dtos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Handlers.UserOperations.Commands.CreateToken
{
    public class CreateTokenCommand
    {
        public CreateTokenModel Model { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CreateTokenCommand(IBookStoreDbContext dbContext, IMapper mapper,IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
            if (user != null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _dbContext.SaveChanges();
                return token;

            }
            else throw new InvalidOperationException("Kullanıcı Adı - Şifre Hatalı");
        }
     }
}
