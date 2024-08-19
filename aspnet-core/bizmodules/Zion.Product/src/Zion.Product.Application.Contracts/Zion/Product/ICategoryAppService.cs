using System;
using Zion.Product.Dtos;
using Volo.Abp.Application.Services;

namespace Zion.Product;


public interface ICategoryAppService :
    ICrudAppService< 
        CategoryDto, 
        Guid, 
        CategoryGetListInput,
        CategoryCreateDto,
        CategoryUpdateDto>
{

}