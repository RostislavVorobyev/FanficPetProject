using FictionDataLayer.Entity;
using FictionDataLayer.Implementations;
using FictionLogicLayer.Mappers;
using System;

namespace FictionLogicLayer.Models
{
    public class CommentaryDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreationTimestamp { get; set; }
        public AuthorDTO Author => GetAuthor();
        public FanficDTO Fanfic => GetFanfic();


        private FanficDTO GetFanfic()
        {
            Fanfic fanfic = new EFRepositoryAbstractFabric().CreateFanficsRepository().GetFanficByComment(Id);
            return new FanficDTO(fanfic.Id, fanfic.Name, fanfic.Description, fanfic.RatingValue,
                fanfic.CreationTimestamp, fanfic.LastUpdateTimestamp);
        }
        private AuthorDTO GetAuthor() {
            return new EFRepositoryAbstractFabric().CreateAuthorsRepository().GetAuthorByComment(Id).ToModel();
        }

    }
}