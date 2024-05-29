using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.Domain.Entity
{
    public class Subscriber
    {
		public int Id { get; set; }
		[DisplayName("Подписка")]
        public int SubscribtionId { get; set; }
        [DisplayName("Пользователь")]
        public int UserId { get; set; }
        [DisplayName("Подписка")]
        public Subscription Subscription { get; set; }
        [DisplayName("Пользователь")]
        public User User { get; set; }
    }
}
