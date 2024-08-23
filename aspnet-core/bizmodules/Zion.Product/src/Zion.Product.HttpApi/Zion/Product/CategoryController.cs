using System;
using Zion.Product.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using System.Collections.Generic;
using Zion.Product.ProductContext.Dtos;

namespace Zion.Product.Zion.Product;

[RemoteService(Name = ProductRemoteServiceConsts.RemoteServiceName)]
[Route("/api/product/category")]
public class CategoryController : ProductBaseController, ICategoryAppService
{
    private readonly ICategoryAppService _service;

    public CategoryController(ICategoryAppService service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("")]
        public virtual Task<CategoryDto> CreateAsync(CategoryCreateDto input)
    {
        return _service.CreateAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
        public virtual Task<CategoryDto> UpdateAsync(Guid id, CategoryUpdateDto input)
    {
        return _service.UpdateAsync(id, input);
    }

    [HttpDelete]
    [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
    {
        return _service.DeleteAsync(id);
    }

    [HttpGet]
    [Route("{id}")]
        public virtual Task<CategoryDto> GetAsync(Guid id)
    {
        return _service.GetAsync(id);
    }

    [HttpGet]
    [Route("")]
        public virtual Task<PagedResultDto<CategoryDto>> GetListAsync(CategoryGetListInput input)
    {
        return _service.GetListAsync(input);
    }

    [HttpGet]
    [Route("TreeData")]
    public virtual Task<List<GetCategoryTreeResultItemDto>> GetTreeData()
    {
        return _service.GetTreeData();
    }
    [HttpGet]
    [Route("root-data")]
    public Task<PagedResultDto<CategoryDto>> GetRootListAsync(CategoryGetListInput input)
    {
        return _service.GetRootListAsync(input);
    }
}