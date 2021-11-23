using AutoMapper;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Handlers.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAuthorsQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<AuthorsViewModel> Handle()
        {
            var authorList = _dbContext.Authors.Include(x => x.Books)
                .OrderBy(x => x.Id).ToList();
            List<AuthorsViewModel> vm = _mapper.Map<List<AuthorsViewModel>>(authorList);
            return vm;
        }
    }
}
