using HD.ProfileManager.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using ProductManager.Products;
using Volo.Abp.Application.Dtos;

namespace ProductManager.Web.Pages;

[Authorize]
public class IndexModel : ProductManagerPageModel
{
    private readonly IProductAppService _productAppService;
    public PagedResultDto<ProductDto> Data { get; set; }

    public IndexModel(IProductAppService productAppService) { 
        _productAppService = productAppService; 
    }
    public async void OnGet(PagedAndSortedResultRequestDto input)
    {
        var data = await _productAppService.GetListAsync(input);
        Data = data;
    }
}
