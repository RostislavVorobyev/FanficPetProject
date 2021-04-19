using System;
using System.Collections.Generic;
using System.Linq;
using FictionDataLayer.Entity;
using FictionDataLayer.Interfaces;
using FictionLogicLayer.Mappers;
using FictionLogicLayer.Models;

namespace FictionLogicLayer.Services
{
    public class FanficService : IFanficService
    {
        public RepositoryAbstractFabric _fabric;

        public FanficService()
        {
        }

        public FanficService(RepositoryAbstractFabric fabric)
        {
            _fabric = fabric;
        }

        public void Create(FanficDTO fanfic)
        {
            _fabric.CreateFanficsRepository().Create(fanfic.ToEntity());
        }

        public void Create(string name, string desctiption, string authorId, int genreId)
        {
            _fabric.CreateFanficsRepository().Create(name, desctiption, authorId, genreId);
        }

        public void Delete(FanficDTO fanfic)
        {
            _fabric.CreateFanficsRepository().Delete(fanfic.ToEntity());
        }

        public void Update(FanficDTO fanfic)
        {
            _fabric.CreateFanficsRepository().Update(fanfic.ToEntity());
        }

        public FanficDTO Get(int fanficId)
        {
            return _fabric.CreateFanficsRepository().Get(fanficId).ToModel();
        }

        public IEnumerable<FanficDTO> GetAllFanfics()
        {
            return _fabric.CreateFanficsRepository().GetAll().ToModel();
        }

        public IEnumerable<FanficDTO> GetByGenre(int genreId)
        {
            return _fabric.CreateGenresRepository().GetGenreFanfics(genreId).ToModel();
        }

        public IEnumerable<FanficDTO> GetMostRated(int quantity)
        {
            IEnumerable<Fanfic> fanfics = _fabric.CreateFanficsRepository().GetAll();
            var ratingComparer = Comparer<Fanfic>.Create((x, y) => x.RatingValue > y.RatingValue ? 1 : x.RatingValue > y.RatingValue ? 1 : 0);
            fanfics.ToList().Sort(ratingComparer);
            IEnumerable<Fanfic> mostRated = fanfics.Take(quantity);
            return mostRated.ToModel();
        }

        public IEnumerable<FanficDTO> GetRecentlyUpdated()
        {
            IEnumerable<Fanfic> updatedThisWeek = _fabric.CreateFanficsRepository().GetAll().Where(f => f.LastUpdateTimestamp > GetLastWeekTime());
            return updatedThisWeek.ToModel();
        }

        private DateTime GetLastWeekTime()
        {
            return DateTime.Now.AddDays(-7);
        }
    }
}
