using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace ProductManager.Products
{
    [Authorize]
    public class ProductAppService : ProductManagerAppService, IProductAppService
    {
        private readonly IRepository<Product, Guid> _productRepository;
        public ProductAppService(IRepository<Product, Guid> productRepository) {
            _productRepository = productRepository;
        }

        public async Task<PagedResultDto<ProductDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queries = await _productRepository.GetQueryableAsync();
            var data = queries.ToList();

            var queryable = await _productRepository.WithDetailsAsync(x => x.Category);

            queryable = queryable
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            var products = await AsyncExecuter.ToListAsync(queryable);
            var count = await _productRepository.GetCountAsync();
            return new PagedResultDto<ProductDto>(count,ObjectMapper.Map<List<Product>, List<ProductDto>>(products));
        }

        Task IProductAppService.CreateAsync(CreateUpdateProductDto input)
        {
            throw new NotImplementedException();
        }

        Task<ListResultDto<CategoryLookupDto>> IProductAppService.GetCategoriesAsync()
        {
            throw new NotImplementedException();
        }
       
    }
}
