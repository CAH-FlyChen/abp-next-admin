using System;
using Zion.Product.Dtos;
using Volo.Abp.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zion.Product.ProductContext.Dtos;
using Volo.Abp.Application.Dtos;

namespace Zion.Product;


public interface ICategoryAppService :
    ICrudAppService< 
        CategoryDto, 
        Guid, 
        CategoryGetListInput,
        CategoryCreateDto,
        CategoryUpdateDto>
{
    Task<List<GetCategoryTreeResultItemDto>> GetTreeData(Guid? id, bool isResultIncludeProduct = false);
    Task<PagedResultDto<CategoryDto>> GetRootListAsync(CategoryGetListInput input);
}