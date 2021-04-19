using FictionLogicLayer.Models;
using System.Collections.Generic;

namespace FictionLogicLayer.ServiceInterfaces
{
    public interface ITagService
    {
        IEnumerable<TagDTO> GetAll(); 
    }
}
