using System;
using Zion.Product.ProductContext.Dtos;
using Volo.Abp.Application.Services;

namespace Zion.Product.ProductContext;


/// <summary>
/// 产品单位
/// </summary>
public interface IUnitAppService :
    ICrudAppService< 
                UnitDto, 
        Guid, 
        UnitGetListInput,
        UnitCreateDto,
        UnitUpdateDto>
{

}