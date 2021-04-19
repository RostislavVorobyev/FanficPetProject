using AutoMapper;
using FictionDataLayer.Entity;
using FictionLogicLayer.Models;
using System.Collections.Generic;

namespace FictionLogicLayer.Mappers
{
    public static class CommentaryMapper
    {
        public static CommentaryDTO ToModel(this Comment comment)
        {
            CommentaryDTO commentModel = new CommentaryDTO()
            {
                Id = comment.Id,
                CreationTimestamp = comment.CreationTimestamp,
                Text = comment.Text
            };
            return commentModel;
        }
        public static Comment ToEntity(this CommentaryDTO comment)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CommentaryDTO, Comment>());
            return new Mapper(config).Map<CommentaryDTO, Comment>(comment);
        }
        public static IEnumerable<CommentaryDTO> ToModel(this IEnumerable<Comment> comments)
        {
            List<CommentaryDTO> fanficModels = new List<CommentaryDTO>();
            foreach (var com in comments)
            {
                fanficModels.Add(com.ToModel());
            }
            return fanficModels;
        }
    }
}
