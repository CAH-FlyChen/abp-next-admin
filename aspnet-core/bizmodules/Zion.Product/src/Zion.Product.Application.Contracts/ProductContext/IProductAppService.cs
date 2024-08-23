using System;
using Zion.Product.ProductContext.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Zion.Product.ProductContext;


public interface IProductAppService :
    ICrudAppService<
        ProductDto,
        Guid,
        ProductGetListInput,
        ProductCreateDto,
        ProductUpdateDto>
{
    
}