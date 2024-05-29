using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.Shared.Dto
{
    public class UserDto
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
        [DisplayName("Навыки")]
        public string Skills { get; set; } = string.Empty;
        [DisplayName("Роль")]
        public RoleDto Role { get; set; }
    }
}
