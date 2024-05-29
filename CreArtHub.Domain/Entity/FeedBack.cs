using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.Domain.Entity
{
    public class FeedBack
    {
        public int Id { get; set; }
        [DisplayName("Имя")]
        public string UserName { get; set; } = string.Empty;
        [DisplayName("Почта")]
        public string UserEmail { get; set; } = string.Empty;
        [DisplayName("Тема")]
        public string Title { get; set; } = string.Empty;
        [DisplayName("Сообщение")]
        public string Context { get; set; } = string.Empty;
        [DisplayName("Прочитано?")]
        public bool isReaded { get; set; } = false;
    }
}
