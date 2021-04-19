using AutoMapper;
using FictionDataLayer.Entity;
using FictionLogicLayer.Models;
using System.Collections.Generic;

namespace FictionLogicLayer.Mappers
{
    public static class AuthorMapper
    {
        public static AuthorDTO ToModel(this Author author)
        {
            
            AuthorDTO authorModel = new AuthorDTO()
            {
                Id = author.Id,
                Email = author.Email,
                UserName = author.UserName,
                Status = author.IsBlocked,
            };
            return authorModel;
            /*
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Author, AuthorDTO>()
                            .ForMember("Status", opt => opt.MapFrom(c => c.IsBlocked))
                            .ForMember("Fanfics", opt => opt.Ignore()));
            return new Mapper(config).Map<Author, AuthorDTO>(author);
            */
        }
        public static Author ToEntity(this AuthorDTO author)
        {
            /*
            Author entityAuthor = new Author
            {
                Id = author.Id,
                Email = author.Email,
                UserName = author.UserName,
                IsBlocked = author.Status,
                RoleId = author.Role.Id
            };
            return entityAuthor;
            */
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AuthorDTO, Author>()
                            .ForMember("IsBlocked", opt => opt.MapFrom(c => c.Status)));
            return new Mapper(config).Map<AuthorDTO, Author>(author);
            
        }
        public static IEnumerable<AuthorDTO> ToModel(this IEnumerable<Author> authors)
        {
            List<AuthorDTO> authorModels = new List<AuthorDTO>();
            foreach (var author in authors)
            {
                authorModels.Add(author.ToModel());
            }
            return authorModels;
        }

    }
}
