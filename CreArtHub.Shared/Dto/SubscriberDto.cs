using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.Shared.Dto
{
    public class SubscriberDto
    {
		public int Id { get; set; }
		[DisplayName("Подписка")]
        public int SubscriptionId { get; set; }
        [DisplayName("Пользователь")]
        public int UserId { get; set; }
        [DisplayName("Подписка")]
        public SubscriptionDto Subscription { get; set; }
        [DisplayName("Пользователь")]
        public UserDto User { get; set; }
    }
}
