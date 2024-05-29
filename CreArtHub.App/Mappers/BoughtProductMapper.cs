using CreArtHub.Domain.Entity;
using CreArtHub.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.App.Mappers
{
    public static class BoughtProductMapper
    {
        public static BoughtProductDto ToDto(this BoughtProduct BoughtProduct)
        {
            if (BoughtProduct == null)
            {
                return null;
            }

            BoughtProductDto BoughtProductDto = new BoughtProductDto()
            {
                BuyerId = BoughtProduct.BuyerId,
                ProductId = BoughtProduct.ProductId,
                Buyer = BoughtProduct.Buyer.ToDto(),
                Product = BoughtProduct.Product.ToDto()

            };

            return BoughtProductDto;
        }
        public static BoughtProduct ToEntity(this BoughtProductDto BoughtProductDto)
        {
            if (BoughtProductDto == null)
            {
                return null;
            }

            BoughtProduct BoughtProduct = new BoughtProduct()
            {
                BuyerId = BoughtProductDto.BuyerId,
                ProductId = BoughtProductDto.ProductId,
                Buyer = BoughtProductDto.Buyer.ToEntity(),
                Product = BoughtProductDto.Product.ToEntity()
            };

            return BoughtProduct;
        }
    }
}
