using Zion.Product;
using Zion.Product.Dtos;
using AutoMapper;

namespace Zion.Product;

public class ProductApplicationAutoMapperProfile : Profile
{
    public ProductApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryCreateDto, Category>(MemberList.Source);
        CreateMap<CategoryUpdateDto, Category>(MemberList.Source);
    }
}
