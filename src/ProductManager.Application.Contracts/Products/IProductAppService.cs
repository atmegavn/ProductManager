using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ProductManager.Products
{
    public interface IProductAppService: IApplicationService
    {
        Task<PagedResultDto<ProductDto>> GetListAsync(PagedAndSortedResultRequestDto input);
        Task CreateAsync(CreateUpdateProductDto input);
        Task<ListResultDto<CategoryLookupDto>> GetCategoriesAsync();
    }
}
