using CreArtHub.Domain.Entity;
using CreArtHub.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.App.Mappers
{
    public static class FeedBackMapper
    {
        public static FeedBackDto ToDto(this FeedBack FeedBack)
        {
            if (FeedBack == null)
            {
                return null;
            }

            FeedBackDto FeedBackDto = new FeedBackDto()
            {
                Id = FeedBack.Id,
                UserName = FeedBack.UserName,
                UserEmail = FeedBack.UserEmail,
                Title = FeedBack.Title,
                Context = FeedBack.Context,
                isReaded = FeedBack.isReaded,
            };

            return FeedBackDto;
        }
        public static FeedBack ToEntity(this FeedBackDto FeedBackDto)
        {
            if (FeedBackDto == null)
            {
                return null;
            }

            FeedBack FeedBack = new FeedBack()
            {
                Id = FeedBackDto.Id,
                UserName = FeedBackDto.UserName,
                UserEmail = FeedBackDto.UserEmail,
                Title = FeedBackDto.Title,
                Context = FeedBackDto.Context,
                isReaded = FeedBackDto.isReaded,
            };

            return FeedBack;
        }
    }
}
