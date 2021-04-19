using FictionDataLayer.Interfaces;
using FictionLogicLayer.Mappers;
using FictionLogicLayer.Models;
using FictionLogicLayer.ServiceInterfaces;
using System;
using System.Collections.Generic;

namespace FictionLogicLayer.Services
{
    public class GenreService : IGenreService
    {
        private RepositoryAbstractFabric _fabric;

        public GenreService(RepositoryAbstractFabric fabric)
        {
            _fabric = fabric;
        }

        public IEnumerable<GenreDTO> GetAll()
        {
            return _fabric.CreateGenresRepository().GetAll().ToModel();
        }
    }
}
