using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.Domain.Entity
{
    public class File
    {
        public int Id { get; set; }
        [DisplayName("Пост")]
        public int PostId { get; set; }
        [DisplayName("Название")]
        public string FileName { get; set; } = string.Empty;
        [DisplayName("Путь")]
        public string FilePath { get; set; } = string.Empty;
        [DisplayName("Пост")]
        public Post Post { get; set; }
    }
}
