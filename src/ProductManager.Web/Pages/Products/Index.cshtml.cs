using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using ProductManager.Products;
using Volo.Abp.Application.Dtos;

namespace ProductManager.Web.Pages.Products
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IProductAppService _productAppService;
        public PagedResultDto<ProductDto> Data;
        public IndexModel(IProductAppService productAppService) { 
            _productAppService = productAppService;
        }

        public async void OnGetAsync(PagedAndSortedResultRequestDto input)
        {
           Data = await _productAppService.GetListAsync(input);
        }
    }
}
