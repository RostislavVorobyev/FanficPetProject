using FictionDataLayer.Interfaces;
using FictionLogicLayer.Mappers;
using FictionLogicLayer.Models;
using FictionLogicLayer.ServiceInterfaces;
using System.Collections.Generic;

namespace FictionLogicLayer.Services
{
    public class TagService : ITagService
    {
        public RepositoryAbstractFabric _fabric;

        public TagService(RepositoryAbstractFabric fabric)
        {
            _fabric = fabric;
        }

        public IEnumerable<TagDTO> GetAll()
        {
            return _fabric.CreateTagsRepository().GetAll().ToModel();
        }
    }
}
