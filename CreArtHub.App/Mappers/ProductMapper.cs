using CreArtHub.Domain.Entity;
using CreArtHub.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.App.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToDto(this Product Product)
        {
            if (Product == null)
            {
                return null;
            }

            ProductDto ProductDto = new ProductDto()
            {
                Id = Product.Id,
                Name = Product.Name,
                Description = Product.Description,
                Price = Product.Price,
                BuyerId = Product.BuyerId,
                Buyer = Product.Buyer.ToDto()
            };

            return ProductDto;
        }
        public static Product ToEntity(this ProductDto ProductDto)
        {
            if (ProductDto == null)
            {
                return null;
            }

            Product Product = new Product()
            {
                Id = ProductDto.Id,
                Name = ProductDto.Name,
                Description = ProductDto.Description,
                Price = ProductDto.Price,
                BuyerId = ProductDto.BuyerId,
                Buyer = ProductDto.Buyer.ToEntity()
            };

            return Product;
        }
    }
}
