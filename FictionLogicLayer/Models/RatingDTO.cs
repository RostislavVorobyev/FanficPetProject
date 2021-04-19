using FictionDataLayer.Implementations;
using FictionLogicLayer.Mappers;
using System;

namespace FictionLogicLayer.Models
{
    public class RatingDTO
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public FanficDTO Fanfic => GetFanfic();

        public AuthorDTO Author => GetAuthor();

        private AuthorDTO GetAuthor()
        {
            return new EFRepositoryAbstractFabric().CreateAuthorsRepository().GetAuthorByVote(Id).ToModel();
        }

        private FanficDTO GetFanfic()
        {
            return new EFRepositoryAbstractFabric().CreateFanficsRepository().GetFanficByRating(Id).ToModel();
        }
    }
}