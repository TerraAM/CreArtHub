using CreArtHub.Domain.Entity;
using CreArtHub.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.App.Mappers
{
    public static class SubscriptionMapper
    {
        public static SubscriptionDto ToDto(this Subscription Subscription)
        {
            if (Subscription == null)
            {
                return null;
            }

            SubscriptionDto SubscriptionDto = new SubscriptionDto()
            {
                Id = Subscription.Id,
                AuthorId = Subscription.AuthorId,
                Name = Subscription.Name,
                Description = Subscription.Description,
                Price = Subscription.Price,
                Delay = Subscription.Delay,
                Author = Subscription.Author.ToDto(),
            };

            return SubscriptionDto;
        }
        public static Subscription ToEntity(this SubscriptionDto SubscriptionDto)
        {
            if (SubscriptionDto == null)
            {
                return null;
            }

            Subscription Subscription = new Subscription()
            {
                Id = SubscriptionDto.Id,
                AuthorId = SubscriptionDto.AuthorId,
                Name = SubscriptionDto.Name,
                Description = SubscriptionDto.Description,
                Price = SubscriptionDto.Price,
                Delay = SubscriptionDto.Delay,
                Author = SubscriptionDto.Author.ToEntity(),
            };

            return Subscription;
        }
    }
}
