using CreArtHub.Domain.Entity;
using CreArtHub.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.App.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToDto(this User User)
        {
            if (User == null)
            {
                return null;
            }

            UserDto UserDto = new UserDto()
            {
                Id = User.Id,
                AvatarPath = User.AvatarPath,
                Name = User.Name,
                Email = User.Email,
                Password = User.Password,
                About = User.About,
                Skills = User.Skills,
                RoleId = User.RoleId,
                Role = User.Role.ToDto()
            };

            return UserDto;
        }
        public static User ToEntity(this UserDto UserDto)
        {
            if (UserDto == null)
            {
                return null;
            }

            User User = new User()
            {
                Id = UserDto.Id,
                AvatarPath = UserDto.AvatarPath,
                Name = UserDto.Name,
                Email = UserDto.Email,
                Password = UserDto.Password,
                About = UserDto.About,
                Skills = UserDto.Skills,
                RoleId = UserDto.RoleId,
                Role = UserDto.Role.ToEntity()
            };

            return User;
        }
    }
}
