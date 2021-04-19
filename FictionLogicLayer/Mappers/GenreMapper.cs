using AutoMapper;
using FictionDataLayer.Entity;
using FictionLogicLayer.Models;
using System.Collections.Generic;

namespace FictionLogicLayer.Mappers
{
    public static class GenreMapper
    {
        public static GenreDTO ToModel(this Genre genre)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Genre, GenreDTO>()
            .ForMember("Fanfics", opt => opt.Ignore()));
            return new Mapper(config).Map<Genre, GenreDTO>(genre);
        }
        public static Genre ToEntity(this GenreDTO genre)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GenreDTO, Genre>());
            return new Mapper(config).Map<GenreDTO, Genre>(genre);
        }
        public static IEnumerable<GenreDTO> ToModel(this IEnumerable<Genre> chapters)
        {
            List<GenreDTO> genreModels = new List<GenreDTO>();
            foreach (var chapter in chapters)
            {
                genreModels.Add(chapter.ToModel());
            }
            return genreModels;
        }
    }
}
