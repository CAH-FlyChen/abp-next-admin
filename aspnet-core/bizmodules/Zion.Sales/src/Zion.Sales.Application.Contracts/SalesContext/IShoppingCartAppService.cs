using System;
using Zion.Sales.SalesContext.Dtos;
using Volo.Abp.Application.Services;

namespace Zion.Sales.SalesContext;


public interface IShoppingCartAppService :
    ICrudAppService< 
        ShoppingCartDto, 
        Guid, 
        ShoppingCartGetListInput,
        ShoppingCartCreateDto,
        ShoppingCartUpdateDto>
{

}