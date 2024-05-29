using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.Shared.Dto
{
    public class BoughtProductDto
    {
        public int Id { get; set; }
        [DisplayName("Обладатель")]
        public int BuyerId { get; set; }
        [DisplayName("Товар")]
        public int ProductId { get; set; }
        public UserDto Buyer { get; set; }
        public ProductDto Product { get; set; }
    }
}
