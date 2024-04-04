using lottery.Application.DTOS;
using lottery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lottery.Application.Mapper
{
    public static class ProductMapper
    {

        public static Product MapToEntity(ProductDto dto)
        {
            return new Product
            {
                Name = dto.Name,
                Price = dto.Price,

            };
        }

        public static IEnumerable<ProductDto> MapListToDto(IEnumerable<Product> dto)
        {
            var prodctoDtos = new List<ProductDto>();

            foreach (var @p in dto)
            {
                var prodctoDto = new ProductDto
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Price = p.Price,    
                };

                prodctoDtos.Add(prodctoDto);
            }

            return prodctoDtos;
        }
    }
}
