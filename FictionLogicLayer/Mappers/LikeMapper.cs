using AutoMapper;
using FictionDataLayer.Entity;
using FictionLogicLayer.Models;

namespace FictionLogicLayer.Mappers
{
    public static class LikeMapper
    {
        public static LikeDTO ToModel(this Like like)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Like, LikeDTO>());
            return new Mapper(config).Map<Like, LikeDTO>(like);
        }
        public static Like ToEntity(this LikeDTO like)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LikeDTO, Like>());
            return new Mapper(config).Map<LikeDTO, Like>(like);
        }
    }
}
