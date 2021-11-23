using AutoMapper;
using Core.Entities.Concrete;
using Entities;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name));
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name));
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<CreateUserModel,User>();
            CreateMap<Author,AuthorsViewModel>();
            CreateMap<CreateAuthorModel, Author>();

        }
    }
}
