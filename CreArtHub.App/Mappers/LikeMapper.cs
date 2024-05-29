using CreArtHub.Domain.Entity;
using CreArtHub.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.App.Mappers
{
    public static class LikeMapper
    {
        public static LikeDto ToDto(this Like Like)
        {
            if (Like == null)
            {
                return null;
            }

            LikeDto LikeDto = new LikeDto()
            {
                PostId = Like.PostId,
                UserId = Like.UserId,
                Post = Like.Post.ToDto(),
                User = Like.User.ToDto()
            };

            return LikeDto;
        }
        public static Like ToEntity(this LikeDto LikeDto)
        {
            if (LikeDto == null)
            {
                return null;
            }

            Like Like = new Like()
            {
                PostId = LikeDto.PostId,
                UserId = LikeDto.UserId,
                Post = LikeDto.Post.ToEntity(),
                User = LikeDto.User.ToEntity()
            };

            return Like;
        }
    }
}
