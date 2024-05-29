using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.Shared.Dto
{
    public class PostDto
    {
        public int Id { get; set; }
        [DisplayName("Категория")]
        public int CategoryId { get; set; }
        [DisplayName("Автор")]
        public int AuthorId { get; set; }
        [DisplayName("Заголовок")]
        public string Title { get; set; } = string.Empty;
        [DisplayName("Содержимое")]
        public string Content { get; set; } = string.Empty;
        [DisplayName("Изображение для поста")]
        public string ImgPath { get; set; } = string.Empty;
        [DisplayName("Тэги, указывать через #")]
        public string Tags { get; set; } = string.Empty;
        [DisplayName("Дата создания")]
        public DateTime CreatedAt { get; set; }
        [DisplayName("Отображать только подписчикам?")]
        public bool BySub { get; set; } = false;
        [DisplayName("Автор")]
        public UserDto Author { get; set; }
        [DisplayName("Категория")]
        public CategoryDto Category { get; set; }
    }
}
