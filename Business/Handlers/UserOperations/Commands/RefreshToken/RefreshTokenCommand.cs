using Core.TokenOperations;
using Core.TokenOperations.Models;
using DataAccess.Abstract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Handlers.UserOperations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {

        public string   RefreshToken{ get; set; }
        private readonly IBookStoreDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public RefreshTokenCommand(IBookStoreDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.RefreshToken==RefreshToken && x.RefreshTokenExpireDate>DateTime.Now );
            if (user != null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _dbContext.SaveChanges();
                return token;

            }
            else throw new InvalidOperationException("Geçerli bir Refresh Token bulunamadı.");
        }
    }
}
