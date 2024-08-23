using System;
using Zion.Product.ProductContext.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Zion.Product.ProductContext;

[RemoteService(Name = ProductRemoteServiceConsts.RemoteServiceName)]
[Route("/api/product/unit")]
public class UnitController : ProductBaseController, IUnitAppService
{
    private readonly IUnitAppService _service;

    public UnitController(IUnitAppService service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("")]
        public virtual Task<UnitDto> CreateAsync(UnitCreateDto input)
    {
        return _service.CreateAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
        public virtual Task<UnitDto> UpdateAsync(Guid id, UnitUpdateDto input)
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
        public virtual Task<UnitDto> GetAsync(Guid id)
    {
        return _service.GetAsync(id);
    }

    [HttpGet]
    [Route("")]
        public virtual Task<PagedResultDto<UnitDto>> GetListAsync(UnitGetListInput input)
    {
        return _service.GetListAsync(input);
    }
}