using FictionDataLayer.Implementations;
using FictionLogicLayer.Entities;
using FictionLogicLayer.Mappers;

namespace FictionLogicLayer.Models
{
    public class LikeDTO
    {
        public int Id { get; set; }
        public AuthorDTO Author => GetAuthor();
        public ChapterDTO Chapter => GetChapter();
        private AuthorDTO GetAuthor()
        {
            return new EFRepositoryAbstractFabric().CreateAuthorsRepository().GetAuthorByLike(Id).ToModel();
        }
        private ChapterDTO GetChapter()
        {
            return new EFRepositoryAbstractFabric().CreateChaptersRepository().GetChapterByLike(Id).ToModel();
        }
    }
}