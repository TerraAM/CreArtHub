using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.Shared.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; } = string.Empty;
        [DisplayName("Описание")]
        public string Description { get; set; } = string.Empty;
        [DisplayName("Цена")]
        public double Price { get; set; }
        [DisplayName("Обладатель")]
        public int BuyerId { get; set; }
        public UserDto Buyer { get; set; }
    }
}
