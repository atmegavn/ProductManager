using AutoMapper;
using ProductManager.Products;

namespace ProductManager;

public class ProductManagerApplicationAutoMapperProfile : Profile
{
    public ProductManagerApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Product, ProductDto>();
    }
}
