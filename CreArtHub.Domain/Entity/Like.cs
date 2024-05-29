using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.Domain.Entity
{
    public class Like
    {
        public int Id { get; set; }
        [DisplayName("Запись")]
        public int PostId { get; set; }
        [DisplayName("Пользователь")]
        public int UserId { get; set; }
        public Post Post { get; set; }
        public User User { get; set; }
    }
}
