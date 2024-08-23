using Zion.Sales.SalesContext;
using Zion.Sales.SalesContext.Dtos;
using AutoMapper;

namespace Zion.Sales;

public class SalesApplicationAutoMapperProfile : Profile
{
    public SalesApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<ShoppingCart, ShoppingCartDto>();
        CreateMap<ShoppingCartCreateDto, ShoppingCart>(MemberList.Source);
        CreateMap<ShoppingCartUpdateDto, ShoppingCart>(MemberList.Source);
        CreateMap<ShoppingCartItem, ShoppingCartItemDto>();
        CreateMap<ShoppingCartItemCreateDto, ShoppingCartItem>(MemberList.Source);
        CreateMap<ShoppingCartItemUpdateDto, ShoppingCartItem>(MemberList.Source);
    }
}
