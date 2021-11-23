using AutoMapper;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Handlers.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateAuthorCommand(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(b => b.Name == Model.Name && b.Surname==Model.Surname);
            if (author != null)
                throw new InvalidOperationException("Yazar zaten mevcut");

            author = _mapper.Map<Author>(Model);

            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();
        }
    }
}
