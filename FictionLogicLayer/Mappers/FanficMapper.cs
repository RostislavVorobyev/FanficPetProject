using AutoMapper;
using FictionDataLayer.Entity;
using FictionLogicLayer.Models;
using System.Collections.Generic;

namespace FictionLogicLayer.Mappers
{
    public static class FanficMapper
    {
        public static FanficDTO ToModel(this Fanfic fanfic)
        {
            return new FanficDTO
            {
                Id = fanfic.Id,
                Name = fanfic.Name,
                Description = fanfic.Description,
                CreationDate = fanfic.CreationTimestamp,
                LastUpdateTimestamp = fanfic.LastUpdateTimestamp,
                RatingValue = fanfic.RatingValue
            };
            /*
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Fanfic, FanficDTO>());
            return new Mapper(config).Map<Fanfic, FanficDTO>(fanfic);
            */
        }
        public static Fanfic ToEntity(this FanficDTO fanfic)
        {
            return new Fanfic
            {
                Id = fanfic.Id,
                Name = fanfic.Name,
                Description = fanfic.Description,
                CreationTimestamp = fanfic.CreationDate,
                LastUpdateTimestamp = fanfic.LastUpdateTimestamp,
                AuthorId = fanfic.Author.Id,
                GenreId = fanfic.Genre.Id,
                RatingValue = fanfic.RatingValue,
            };
            /*
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FanficDTO, Fanfic>()
            .ForMember("AuthorId", opt => opt.MapFrom(f => f.Author.Id))
            .ForMember("Author", opt => opt.Ignore())
            .ForMember("GenreId", opt => opt.MapFrom(f => f.Genre.Id))
            .ForMember("Genre", opt => opt.Ignore()));
            return new Mapper(config).Map<FanficDTO, Fanfic>(fanfic);
            */
        }
        public static IEnumerable<FanficDTO> ToModel(this IEnumerable<Fanfic> fanfics)
        {
            List<FanficDTO> fanficModels = new List<FanficDTO>();
            foreach (var fanfic in fanfics)
            {
                fanficModels.Add(fanfic.ToModel());
            }
            return fanficModels;
        }
    }
}
