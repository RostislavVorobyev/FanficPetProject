using FictionLogicLayer.Models;
using System.Collections.Generic;

namespace FictionLogicLayer
{
    public interface IFanficService
    {
        IEnumerable<FanficDTO> GetAllFanfics();
        FanficDTO Get(int fanficId);
        IEnumerable<FanficDTO> GetByGenre(int genreId);
        IEnumerable<FanficDTO> GetRecentlyUpdated();
        IEnumerable<FanficDTO> GetMostRated(int quantity);

        void Create(FanficDTO fanfic);
        void Create(string name, string desctiption, string authorId, int genreId);
        void Delete(FanficDTO fanfic);
        void Update(FanficDTO fanfic);
    }
}
