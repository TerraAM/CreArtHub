using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.Domain.Entity
{
    public class User
    {
        public int Id { get; set; }
        [DisplayName("Роль")]
        public int RoleId { get; set; }
        [DisplayName("Аватарка")]
        public string AvatarPath { get; set; } = string.Empty;
        [DisplayName("Псевдоним")]
        public string Name { get; set; } = string.Empty;
        [DisplayName("Почта")]
        public string Email { get; set; } = string.Empty;
        [DisplayName("Пароль")]
        public string Password { get; set; } = string.Empty;
        [DisplayName("Обо мне")]
        public string About { get; set; } = string.Empty;
        [DisplayName("Навыки (вводить через ,)")]
        public string Skills { get; set; } = string.Empty;
        [DisplayName("Роль")]
        public Role Role { get; set; }
    }
}
