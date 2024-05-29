using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.Domain.Entity
{
    public class BoughtProduct
    {
		public int Id { get; set; }
		[DisplayName("Обладатель")]
        public int BuyerId { get; set; }
        [DisplayName("Товар")]
        public int ProductId { get; set; }
        public User Buyer { get; set; }
        public Product Product { get; set; }
    }
}
