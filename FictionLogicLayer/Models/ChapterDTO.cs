using FictionDataLayer.Entity;
using FictionDataLayer.Implementations;
using FictionLogicLayer.Mappers;
using FictionLogicLayer.Models;
using System;
using System.Collections.Generic;

namespace FictionLogicLayer.Entities
{
    public class ChapterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int ChapterNumber { get; set; }
        public int LikesCounter { get; set; }
        public byte[] Image { get; set; }
        public FanficDTO Fanfic => GetFanfic();
        public List<LikeDTO> Likes => GetLikes();

        public ChapterDTO()
        {
        }
        public ChapterDTO(string name, string text, int chapterNumber, int likesCounter, byte[] image)
        {
            Name = name;
            Text = text;
            ChapterNumber = chapterNumber;
            LikesCounter = likesCounter;
            Image = image;
        }

        private List<LikeDTO> GetLikes()
        {
            IEnumerable<Like> entityLikes = new EFRepositoryAbstractFabric().CreateChaptersRepository().GetChapterLikes(Id);
            List<LikeDTO> modelRatings = new List<LikeDTO>();
            foreach (var like in entityLikes)
            {
                modelRatings.Add(like.ToModel());
            }
            return modelRatings;
        }

        internal void Where()
        {
            throw new NotImplementedException();
        }

        private FanficDTO GetFanfic()
        {
            return new EFRepositoryAbstractFabric().CreateFanficsRepository().GetFanficByChapter(Id).ToModel();
        }
    }
}
