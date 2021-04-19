using FictionLogicLayer.Models;
using System.Collections.Generic;

namespace FictionUILayer.ViewModels
{
    public class FanficCreationViewModel
    {
        public IEnumerable<GenreDTO> Genres { get; set; }
        public IEnumerable<TagDTO> Tags { get; set; }
    }
}
