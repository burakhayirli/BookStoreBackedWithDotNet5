using AutoMapper;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Handlers.UserOperations.Commands.CreateUser
{
    public class CreateUserCommand
    {
        public CreateUserModel Model { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateUserCommand(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var user = _dbContext.Users.SingleOrDefault(b => b.Email == Model.Email);
            if (user != null)
                throw new InvalidOperationException("Kullanıcı zaten mevcut");

            user = _mapper.Map<User>(Model);

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }
    }
}
