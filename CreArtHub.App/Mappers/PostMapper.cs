using CreArtHub.Domain.Entity;
using CreArtHub.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.App.Mappers
{
    public static class PostMapper
    {
        public static PostDto ToDto(this Post Post)
        {
            if (Post == null)
            {
                return null;
            }

            PostDto PostDto = new PostDto()
            {
                Id = Post.Id,
                Title = Post.Title,
                Content = Post.Content,
                Tags = Post.Tags,
                CreatedAt = Post.CreatedAt,
                BySub = Post.BySub,
                AuthorId = Post.AuthorId,
                Author = Post.Author.ToDto(),
                CategoryId = Post.CategoryId,
                Category = Post.Category.ToDto(),
            };

            return PostDto;
        }
        public static Post ToEntity(this PostDto PostDto)
        {
            if (PostDto == null)
            {
                return null;
            }

            Post Post = new Post()
            {
                Id = PostDto.Id,
                Title = PostDto.Title,
                Content = PostDto.Content,
                Tags = PostDto.Tags,
                CreatedAt = PostDto.CreatedAt,
                BySub = PostDto.BySub,
				AuthorId = PostDto.AuthorId,
				Author = PostDto.Author.ToEntity(),
                CategoryId = PostDto.CategoryId,
                Category = PostDto.Category.ToEntity(),
            };

            return Post;
        }
    }
}
