using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.Domain.Entity
{
    public class Comment
    {
        public int Id { get; set; }
        [DisplayName("Пост")]
        public int PostId { get; set; }
        [DisplayName("Автор")]
        public int AuthorId { get; set; }
        [DisplayName("Содержание")]
        public string Content { get; set; } = string.Empty;
        [DisplayName("Дата создания")]
        public DateTime CreatedAt { get; set; }
        [DisplayName("Изменялся?")]
        public bool IsEdit { get; set; } = false;
        public Post Post { get; set; }
        public User Author { get; set; }
    }
}
