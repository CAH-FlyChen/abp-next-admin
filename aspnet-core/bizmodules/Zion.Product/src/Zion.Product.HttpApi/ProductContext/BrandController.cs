using System;
using Zion.Product.ProductContext.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Zion.Product.ProductContext;

[RemoteService(Name = ProductRemoteServiceConsts.RemoteServiceName)]
[Route("/api/product/brand")]
public class BrandController : ProductController, IBrandAppService
{
    private readonly IBrandAppService _service;

    public BrandController(IBrandAppService service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("")]
        public virtual Task<BrandDto> CreateAsync(BrandCreateDto input)
    {
        return _service.CreateAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
        public virtual Task<BrandDto> UpdateAsync(Guid id, BrandUpdateDto input)
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
        public virtual Task<BrandDto> GetAsync(Guid id)
    {
        return _service.GetAsync(id);
    }

    [HttpGet]
    [Route("")]
        public virtual Task<PagedResultDto<BrandDto>> GetListAsync(BrandGetListInput input)
    {
        return _service.GetListAsync(input);
    }
}