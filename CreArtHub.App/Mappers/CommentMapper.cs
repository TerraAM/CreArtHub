using CreArtHub.Domain.Entity;
using CreArtHub.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.App.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToDto(this Comment Comment)
        {
            if (Comment == null)
            {
                return null;
            }

            CommentDto CommentDto = new CommentDto()
            {
                Id = Comment.Id,
                PostId = Comment.PostId,
                AuthorId = Comment.AuthorId,
                Content = Comment.Content,
                CreatedAt = Comment.CreatedAt,
                IsEdit = Comment.IsEdit,
                Post = Comment.Post.ToDto(),
                Author = Comment.Author.ToDto(),
            };

            return CommentDto;
        }
        public static Comment ToEntity(this CommentDto CommentDto)
        {
            if (CommentDto == null)
            {
                return null;
            }

            Comment Comment = new Comment()
            {
                Id = CommentDto.Id,
                PostId = CommentDto.PostId,
                AuthorId = CommentDto.AuthorId,
                Content = CommentDto.Content,
                CreatedAt = CommentDto.CreatedAt,
                IsEdit = CommentDto.IsEdit,
                Post = CommentDto.Post.ToEntity(),
                Author = CommentDto.Author.ToEntity(),
            };

            return Comment;
        }
    }
}
