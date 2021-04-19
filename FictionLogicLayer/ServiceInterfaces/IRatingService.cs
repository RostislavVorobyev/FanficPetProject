using FictionLogicLayer.Models;

namespace FictionLogicLayer
{
    public interface IRatingService
    {
        void Rate (RatingDTO rating);
        void Rate (int fanficId, string authorId, int value);
    }
}
