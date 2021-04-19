using FictionDataLayer.Entity;
using FictionDataLayer.Implementations;
using FictionLogicLayer.Entities;
using FictionLogicLayer.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FictionLogicLayer.Models
{
    public class FanficDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double RatingValue { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateTimestamp { get; set; }
        public AuthorDTO Author => GetAuthor();
        public GenreDTO Genre => GetGenre();
        public List<RatingDTO> Ratings => GetRatings();
        public List<Tag> Tags => GetTags();
        public List<ChapterDTO> Chapters => GetChapters();
        public List<CommentaryDTO> Comments => GetComments();
        
        public FanficDTO() { }
        public FanficDTO(int id, string name, string description, double ratingValue, DateTime creationDate, DateTime lastUpdateTime)
        {
            Id = id;
            Name = name;
            Description = description;
            RatingValue = ratingValue;
            CreationDate = creationDate;
            LastUpdateTimestamp = lastUpdateTime;
        }
        private GenreDTO GetGenre()
        {
            return new EFRepositoryAbstractFabric().CreateGenresRepository().GetGenreByFanfic(Id).ToModel();
        }
        private AuthorDTO GetAuthor()
        {
            return new EFRepositoryAbstractFabric().CreateAuthorsRepository().GetAuthorByFanfic(Id).ToModel();
        }
        private List<Tag> GetTags()
        {
            FanficRepository repo = new FanficRepository();
            return repo.GetFanficTags(Id).ToList();
        }
        private List<RatingDTO> GetRatings()
        {
            FanficRepository repo = new FanficRepository();
            return repo.GetFanficRatings(Id).ToModel().ToList();

        }
        private List<ChapterDTO> GetChapters()
        {
            FanficRepository repo = new FanficRepository();
            return repo.GetFanficChapters(Id).ToModel().ToList();
        }
        private List<CommentaryDTO> GetComments()
        {
            FanficRepository repo = new FanficRepository();
            return repo.GetFanficComments(Id).ToModel().ToList();
        }
    }
}
