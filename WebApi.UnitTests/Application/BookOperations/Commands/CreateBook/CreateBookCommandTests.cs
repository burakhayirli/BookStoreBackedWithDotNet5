using AutoMapper;
using Business.Handlers.BookOperations.CreateBook;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //Arrange (Hazırlık)
            var book = new Book()
            {
                Title = "Test_WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn",
                PageCount = 120,
                PublishDate = new DateTime(1992, 01, 15),
                GenreId = 1
            };
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = new CreateBookModel() { Title = book.Title };

            //Act  & Assert(Çalıştırma -Doğrulama)
            FluentActions.
                Invoking(() => command.Handle()).
                Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut");

            //Assert (Doğrulama)
        }

        [Fact]
        public void WhenValidInputAreGiven_Book_ShouldBeGreated()
        {
            //Arrange
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            CreateBookModel model = new CreateBookModel()
            {
                Title = "Two And A Half Men",
                PageCount=800,
                PublishDate=DateTime.Now.Date.AddYears(-5),
                GenreId=1
            };

            command.Model = model;

            //Act
            FluentActions.Invoking(() =>command.Handle()).Invoke();

            //Assert
            var book = _context.Books.SingleOrDefault(book => book.Title == model.Title);
            book.Should().NotBeNull();
            book.PageCount.Should().Be(model.PageCount);
            book.PublishDate.Should().Be(model.PublishDate);
            //book.Title.Should().Be(model.Title); //Çalışmayacak olan kural
            book.GenreId.Should().Be(model.GenreId);
        }
    }
}
