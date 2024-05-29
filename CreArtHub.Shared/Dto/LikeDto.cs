using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.Shared.Dto
{
    public class LikeDto
    {
		public int Id { get; set; }
		[DisplayName("Запись")]
        public int PostId { get; set; }
        [DisplayName("Пользователь")]
        public int UserId { get; set; }
        public PostDto Post { get; set; }
        public UserDto User { get; set; }
    }
}
