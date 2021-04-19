using FictionDataLayer.Interfaces;
using FictionLogicLayer.Mappers;
using FictionLogicLayer.Models;
using FictionLogicLayer.ServiceInterfaces;

namespace FictionLogicLayer.Services
{
    public class CommentaryService : ICommentaryService
    {
        private RepositoryAbstractFabric _fabric;

        public CommentaryService()
        {
        }

        public CommentaryService(RepositoryAbstractFabric fabric)
        {
            _fabric = fabric;
        }

        public void Create(CommentaryDTO commentary)
        {
            _fabric.CreateCommentsRepository().Create(commentary.ToEntity());
        }

        public void Create(string text, string authorId, int fanficId)
        {
            _fabric.CreateCommentsRepository().Create(text, authorId, fanficId);
        }

        public void Delete(CommentaryDTO commentary)
        {
            _fabric.CreateCommentsRepository().Delete(commentary.ToEntity());
        }

        public void Edit(CommentaryDTO commentary)
        {
            _fabric.CreateCommentsRepository().Update(commentary.ToEntity());
        }
    }
}
