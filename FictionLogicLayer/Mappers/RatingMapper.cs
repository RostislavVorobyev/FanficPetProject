using AutoMapper;
using FictionDataLayer.Entity;
using FictionLogicLayer.Models;
using System.Collections.Generic;

namespace FictionLogicLayer.Mappers
{
    public static class RatingMapper
    {
        public static RatingDTO ToModel(this Rating rating)
        {
            RatingDTO entityRating = new RatingDTO()
            {
                Id = rating.Id,
                Value = rating.Value,
            };
            return entityRating;
        }
        public static Rating ToEntity(this RatingDTO rating)
        {
            Rating entityRating = new Rating()
            {
                Id = rating.Id,
                Value = rating.Value,
                AuthorId = rating.Author.Id,
                FanficId = rating.Fanfic.Id
            };
            return entityRating;
        }

        public static IEnumerable<RatingDTO> ToModel(this IEnumerable<Rating> ratings)
        {
            List<RatingDTO> ratingsModels = new List<RatingDTO>();
            foreach (var rating in ratings)
            {
                ratingsModels.Add(rating.ToModel());
            }
            return ratingsModels;
        }
    }
}
