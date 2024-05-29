using CreArtHub.Domain.Entity;
using CreArtHub.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.App.Mappers
{
    public static class SubscriberMapper
    {
        public static SubscriberDto ToDto(this Subscriber Subscriber)
        {
            if (Subscriber == null)
            {
                return null;
            }

            SubscriberDto SubscriberDto = new SubscriberDto()
            {
                SubscribtionId = Subscriber.SubscribtionId,
                UserId = Subscriber.UserId,
                Subscription = Subscriber.Subscription.ToDto(),
                User = Subscriber.User.ToDto()
            };

            return SubscriberDto;
        }
        public static Subscriber ToEntity(this SubscriberDto SubscriberDto)
        {
            if (SubscriberDto == null)
            {
                return null;
            }

            Subscriber Subscriber = new Subscriber()
            {
                SubscribtionId = SubscriberDto.SubscribtionId,
                UserId = SubscriberDto.UserId,
                Subscription = SubscriberDto.Subscription.ToEntity(),
                User = SubscriberDto.User.ToEntity()
            };

            return Subscriber;
        }
    }
}
