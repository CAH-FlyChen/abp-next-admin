using System;
using Zion.Product.ProductContext.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Zion.Product.ProductContext;


public interface IProductAppService :
    ICrudAppService<
        ProductDto,
        Guid,
        ProductGetListInput,
        ProductCreateDto,
        ProductUpdateDto>
{
    Task<PagedResultDto<ProductDto>> GetNewListAsync(ProductGetListInput input);
    Task<PagedResultDto<ProductDto>> GetHotListAsync(ProductGetListInput input);
}