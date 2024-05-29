using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.Shared.Dto
{
    public class SubscriptionDto
    {
        public int Id { get; set; }
        [DisplayName("Автор")]
        public int AuthorId { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; } = string.Empty;
        [DisplayName("Описание")]
        public string Description { get; set; } = string.Empty;
        [DisplayName("Цена")]
        public double Price { get; set; }
        [DisplayName("Продолжительность")]
        public double Delay { get; set; }
        [DisplayName("Автор")]
        public UserDto Author { get; set; }
    }
}
