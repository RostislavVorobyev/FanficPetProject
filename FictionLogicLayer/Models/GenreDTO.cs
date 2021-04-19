using FictionDataLayer.Entity;
using FictionDataLayer.Implementations;
using FictionLogicLayer.Mappers;
using System.Collections.Generic;

namespace FictionLogicLayer.Models
{
    public class GenreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<FanficDTO> Fanfics => GetFanfics();
        private List<FanficDTO> GetFanfics()
        {
            IEnumerable<Fanfic> entityFanfics = new EFRepositoryAbstractFabric().CreateGenresRepository().GetGenreFanfics(Id);
            List<FanficDTO> modelFanfics = new List<FanficDTO>();
            foreach (var f in entityFanfics)
            {
                modelFanfics.Add(f.ToModel());
            }
            return modelFanfics;
        }
    }
}