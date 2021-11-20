using AutoMapper;
using Business.Helpers;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.UnitTests.TestSetup
{
   public  class CommonTestFixture
    {
        public BookStoreContext Context{ get; set; }
        public IMapper Mapper;

        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<BookStoreContext>().UseInMemoryDatabase("BookStoreTestDB").Options;
            Context =new BookStoreContext(options);
            
            Context.Database.EnsureCreated();
            Context.AddBooks();
            Context.AddGenres();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }).CreateMapper();
        }
    }
}
