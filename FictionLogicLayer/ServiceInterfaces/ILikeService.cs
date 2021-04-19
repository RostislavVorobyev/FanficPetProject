using FictionLogicLayer.Models;

namespace FictionLogicLayer.ServiceInterfaces
{
    public interface ILikeService
    {
        void Like(LikeDTO rating);
        void Like(int chapterId, string authorId);
    }
}
