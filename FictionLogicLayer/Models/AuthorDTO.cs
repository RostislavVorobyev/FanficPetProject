using FictionDataLayer.Entity;
using FictionDataLayer.Implementations;
using FictionLogicLayer.Mappers;
using FictionLogicLayer.Models;
using System.Collections.Generic;

namespace FictionLogicLayer.Models
{
    public class AuthorDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public bool Status { get; set; }
        

        public List<RatingDTO> Votes => GetVotes();
        public List<FanficDTO> Fanfics => GetFanfics();

        public AuthorDTO() { }
        public AuthorDTO(string email, string userName, bool status)
        {
            Email = email;
            UserName = userName;
            Status = status;
        }
        public AuthorDTO(string id, string email, string userName, bool status)
        {
            Id = id;
            Email = email;
            UserName = userName;
            Status = status;
        }

        private List<RatingDTO> GetVotes()
        {
            IEnumerable<Rating> entityRatings = new EFRepositoryAbstractFabric().CreateAuthorsRepository().GetAuthorVotes(Id);
            List<RatingDTO> modelRatings = new List<RatingDTO>();
            foreach (var r in entityRatings)
            {
                modelRatings.Add(r.ToModel());
            }
            return modelRatings;
        }
        private List<FanficDTO> GetFanfics()
        {
            IEnumerable<Fanfic> entityFanfics = new EFRepositoryAbstractFabric().CreateAuthorsRepository().GetAuthorFanfics(Id);
            List<FanficDTO> modelFanfics = new List<FanficDTO>();
            foreach (var f in entityFanfics)
            {
                modelFanfics.Add(f.ToModel());
            }
            return modelFanfics;
        }
    }
}
