using lottery.Application.DTOS;
using lottery.Application.InterfaceLotteryUseCase;
using lottery.Application.Mapper;
using lottery.Domain.Repository;
using lottery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lottery.Application.LotteryUseCaseImpl
{
    /*implementa la interfaz ILotteryProductUseCase */
    public class LotteryProductUseCaseImpl : ILotteryProductUseCase
    {

        private readonly IGenericRepository<Product> _genericRepository;
        private readonly IProductReposity _productRepository;

        public LotteryProductUseCaseImpl(IGenericRepository<Product> genericRepository, IProductReposity productRepository)
        {
            _genericRepository = genericRepository;
            _productRepository = productRepository;
        }
        public void AddProdct(ProductDto dto)
        { 
            Product info = ProductMapper.MapToEntity(dto);
            _productRepository.saveProduct(info);

        }

        public Task<IEnumerable<ProductDto>> GetProductList()
        {
            IEnumerable<Product> info = _genericRepository.ListInformation();
            IEnumerable<ProductDto> productDto = ProductMapper.MapListToDto(info);
            return Task.FromResult(productDto);
        }

        
    }
}
