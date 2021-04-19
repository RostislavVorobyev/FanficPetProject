using FictionLogicLayer;
using FictionLogicLayer.Models;
using System.Collections.Generic;

namespace FictionUILayer.Models
{
    public class HomeViewModel
    {
        public IEnumerable<FanficDTO> RecentlyUpdated { get; set; }
        public IEnumerable<FanficDTO> MostRated { get; set; }

    }
}
