using FictionDataLayer.Interfaces;
using FictionLogicLayer.Mappers;
using FictionLogicLayer.Models;
using System.Linq;

namespace FictionLogicLayer.Services
{
    public class RatingService : IRatingService
    {
        private RepositoryAbstractFabric _fabric;

        public RatingService(RepositoryAbstractFabric fabric)
        {
            _fabric = fabric;
        }

        public void Rate(int fanficId, string authorId, int value)
        {
            var userVoteForFanfic = GetUserVote(fanficId, authorId);
            if (userVoteForFanfic == null)
            {
                _fabric.CreateRatingsRepository().Create(value, fanficId, authorId);
            }
            else
            {
                userVoteForFanfic.Value = value;
                _fabric.CreateRatingsRepository().Update(userVoteForFanfic.ToEntity());
            }
            RecalculateFanficRating(fanficId);
        }

        public void Rate(RatingDTO rating)
        {
            _fabric.CreateRatingsRepository().Create(rating.ToEntity());
        }

        private RatingDTO GetUserVote(int fanficId, string authorId)
        {
            return _fabric.CreateFanficsRepository().Get(fanficId).ToModel().Ratings.FirstOrDefault(r => r.Author.Id.Equals(authorId));
        }

        private void RecalculateFanficRating(int fanficId)
        {
            FanficDTO fanfic = _fabric.CreateFanficsRepository().Get(fanficId).ToModel();
            fanfic.RatingValue = fanfic.Ratings.Average(r => r.Value);
            _fabric.CreateFanficsRepository().Update(fanfic.ToEntity());
        }
    }
}
