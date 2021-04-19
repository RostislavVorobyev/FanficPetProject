using FictionLogicLayer.Models;

namespace FictionLogicLayer.ServiceInterfaces
{
    public interface ICommentaryService
    {
        void Create(CommentaryDTO commentary);
        void Create(string text, string authorId, int fanficId);
        void Edit(CommentaryDTO commentary);
        void Delete(CommentaryDTO commentary);
    }
}
