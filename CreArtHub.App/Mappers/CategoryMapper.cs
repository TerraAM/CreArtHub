using CreArtHub.Domain.Entity;
using CreArtHub.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.App.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToDto(this Category Category)
        {
            if (Category == null)
            {
                return null;
            }

            CategoryDto CategoryDto = new CategoryDto()
            {
                Id = Category.Id,
                Name = Category.Name,
            };

            return CategoryDto;
        }
        public static Category ToEntity(this CategoryDto CategoryDto)
        {
            if (CategoryDto == null)
            {
                return null;
            }

            Category Category = new Category()
            {
                Id = CategoryDto.Id,
                Name = CategoryDto.Name,
            };

            return Category;
        }
    }
}
