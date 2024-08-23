using System;
using Zion.Product.ProductContext.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using System.Collections.Generic;

namespace Zion.Product.ProductContext;

[RemoteService(Name = ProductRemoteServiceConsts.RemoteServiceName)]
[Route("/api/product/product")]
public class ProductController : ProductBaseController, IProductAppService
{
    private readonly IProductAppService _service;

    public ProductController(IProductAppService service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("")]
        public virtual Task<ProductDto> CreateAsync(ProductCreateDto input)
    {
        return _service.CreateAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
        public virtual Task<ProductDto> UpdateAsync(Guid id, ProductUpdateDto input)
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
        public virtual Task<ProductDto> GetAsync(Guid id)
    {
        return _service.GetAsync(id);
    }

    [HttpGet]
    [Route("")]
        public virtual Task<PagedResultDto<ProductDto>> GetListAsync(ProductGetListInput input)
    {
        return _service.GetListAsync(input);
    }


}