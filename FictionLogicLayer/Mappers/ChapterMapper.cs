using AutoMapper;
using FictionDataLayer.Entity;
using FictionLogicLayer.Entities;
using System.Collections.Generic;

namespace FictionLogicLayer.Mappers
{
    public static class ChapterMapper
    {
        public static ChapterDTO ToModel(this Chapter chapter)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Chapter, ChapterDTO>());
            return new Mapper(config).Map<Chapter, ChapterDTO>(chapter);
        }
        public static Chapter ToEntity(this ChapterDTO chapter)
        {
            var entityChapter = new Chapter
            {
                Id = chapter.Id,
                Name = chapter.Name,
                ChapterNumber = chapter.ChapterNumber,
                FanficId = chapter.Fanfic.Id,
                LikesCounter = chapter.LikesCounter,
                Text = chapter.Text,
                Image = chapter.Image
            };
            return entityChapter;
        }
        public static IEnumerable<ChapterDTO> ToModel(this IEnumerable<Chapter> chapters)
        {
            List<ChapterDTO> chapterModels = new List<ChapterDTO>();
            foreach (var chapter in chapters)
            {
                chapterModels.Add(chapter.ToModel());
            }
            return chapterModels;
        }
    }
}
