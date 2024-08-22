using System;
using Zion.Product.ProductContext.Dtos;
using Volo.Abp.Application.Services;

namespace Zion.Product.ProductContext;


/// <summary>
/// 产品品牌
/// </summary>
public interface IBrandAppService :
    ICrudAppService< 
                BrandDto, 
        Guid, 
        BrandGetListInput,
        BrandCreateDto,
        BrandUpdateDto>
{

}