using FictionLogicLayer.Models;
using System.Collections.Generic;

namespace FictionLogicLayer.ServiceInterfaces
{
    public interface IGenreService
    {
        IEnumerable<GenreDTO> GetAll();
    }
}
