using FictionDataLayer.Interfaces;
using FictionLogicLayer.Entities;
using FictionLogicLayer.Mappers;
using FictionLogicLayer.Models;
using FictionLogicLayer.ServiceInterfaces;
using System.Linq;

namespace FictionLogicLayer.Services
{
    public class LikeService : ILikeService
    {
        private RepositoryAbstractFabric _fabric;

        public LikeService(RepositoryAbstractFabric fabric)
        {
            _fabric = fabric;
        }

        public void Like(LikeDTO rating)
        {
            throw new System.NotImplementedException();
        }

        public void Like(int chapterId, string authorId)
        {
            var userLikeForChapter = GetUserLikes(chapterId, authorId);
            if (userLikeForChapter == null)
            {
                _fabric.CreateLikesRepository().Create(authorId, chapterId);
            }
            else
            {
                _fabric.CreateLikesRepository().DeleteLike(userLikeForChapter.Id);
            }
            UpdateChapterLikes(chapterId);
        }

        private LikeDTO GetUserLikes(int chapterId, string authorId)
        {
            return _fabric.CreateChaptersRepository().Get(chapterId).ToModel().Likes.FirstOrDefault(r => r.Author.Id.Equals(authorId));
        }

        private void UpdateChapterLikes(int chapterId)
        {
            ChapterDTO chapter = _fabric.CreateChaptersRepository().Get(chapterId).ToModel();
            chapter.LikesCounter = chapter.Likes.Count;
            _fabric.CreateChaptersRepository().Update(chapter.ToEntity());
        }

    }
}
