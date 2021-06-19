﻿using AutoMapper;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Handlers.BookOperations.GetBooks
{
    public class GetBookByIdQuery
    {
        public int Id { get; set; }
        private readonly BookStoreContext _dbContext;
        private readonly IMapper _mapper;

        public GetBookByIdQuery(BookStoreContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            _mapper = mapper;
        }

        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Where(book => book.Id == this.Id).SingleOrDefault();

            if (book == null)
                throw new InvalidOperationException("Kitap bulunamadı");

            BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);
            return vm;
        }
    }



}