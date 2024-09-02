using System;
using Zion.Product.PriceContext.Dtos;
using Volo.Abp.Application.Services;

namespace Zion.Product.PriceContext;


public interface IPriceAppService :
    ICrudAppService< 
        PriceDto, 
        Guid, 
        PriceGetListInput,
        PriceCreateDto,
        PriceUpdateDto>
{

}