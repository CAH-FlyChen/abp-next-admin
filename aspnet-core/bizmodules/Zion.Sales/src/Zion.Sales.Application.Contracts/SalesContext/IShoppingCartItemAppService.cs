using System;
using Zion.Sales.SalesContext.Dtos;
using Volo.Abp.Application.Services;

namespace Zion.Sales.SalesContext;


public interface IShoppingCartItemAppService :
    ICrudAppService< 
        ShoppingCartItemDto, 
        Guid, 
        ShoppingCartItemGetListInput,
        ShoppingCartItemCreateDto,
        ShoppingCartItemUpdateDto>
{

}