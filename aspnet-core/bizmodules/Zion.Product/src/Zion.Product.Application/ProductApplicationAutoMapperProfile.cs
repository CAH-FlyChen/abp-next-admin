using Zion.Product;
using Zion.Product.Dtos;
using Zion.Product.ProductContext.Dtos;
using AutoMapper;

namespace Zion.Product.ProductContext;

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
        CreateMap<Brand, BrandDto>();
        CreateMap<BrandCreateDto, Brand>(MemberList.Source);
        CreateMap<BrandUpdateDto, Brand>(MemberList.Source);
        CreateMap<Unit, UnitDto>();
        CreateMap<UnitCreateDto, Unit>(MemberList.Source);
        CreateMap<UnitUpdateDto, Unit>(MemberList.Source);
        CreateMap<Product, ProductDto>(MemberList.None);
        CreateMap<ProductCreateDto, Product>(MemberList.Source);
        CreateMap<ProductUpdateDto, Product>(MemberList.Source);
    }
}
