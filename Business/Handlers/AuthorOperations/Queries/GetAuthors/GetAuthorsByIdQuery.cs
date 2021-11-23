using AutoMapper;
using DataAccess.Abstract;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Handlers.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsByIdQuery
    {
        public int Id { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAuthorsByIdQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            _mapper = mapper;
        }

        public AuthorsViewModel Handle()
        {
            var author = _dbContext.Authors.Include(x => x.Books).Where(author => author.Id == this.Id).SingleOrDefault();

            if (author == null)
                throw new InvalidOperationException("Yazar bulunamadı");

            AuthorsViewModel vm = _mapper.Map<AuthorsViewModel>(author);
            return vm;
        }
    }
}
