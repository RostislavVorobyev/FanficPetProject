using AutoMapper;
using FictionDataLayer.Entity;
using FictionLogicLayer.Entities;
using FictionLogicLayer.Models;
using System.Collections.Generic;

namespace FictionLogicLayer.Mappers
{
    public static class TagMapper
    {
        public static TagDTO ToModel(this Tag tag)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Tag, TagDTO>());
            return new Mapper(config).Map<Tag, TagDTO>(tag);
        }
        public static Tag ToEntity(this TagDTO tag)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TagDTO, Tag>());
            return new Mapper(config).Map<TagDTO, Tag>(tag);
        }
        public static IEnumerable<TagDTO> ToModel(this IEnumerable<Tag> tags)
        {
            List<TagDTO> tagModels = new List<TagDTO>();
            foreach (var t in tags)
            {
                tagModels.Add(t.ToModel());
            }
            return tagModels;
        }
    }
}
