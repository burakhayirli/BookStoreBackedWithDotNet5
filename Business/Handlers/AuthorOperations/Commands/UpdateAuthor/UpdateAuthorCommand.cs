using DataAccess.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Handlers.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public UpdateAuthorModel Model { get; set; }
        public int Id { get; set; }
        private readonly IBookStoreDbContext _dbContext;

        public UpdateAuthorCommand(IBookStoreDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(b => b.Id == this.Id);

            if (author is null)
                throw new InvalidOperationException("Boş veri gönderilemez. Lütfen verdiğiniz bilgileri kontrol ediniz.");

            author.Name = Model.Name != default ? Model.Name: author.Name;
            author.Surname = Model.Surname != default ? Model.Surname : author.Surname;
            author.BirthDate = Model.BirthDate != default ? Model.BirthDate : author.BirthDate;
            _dbContext.SaveChanges();
        }
    }
}
