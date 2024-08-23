using System;
using Zion.System.AdContext.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Zion.System.AdContext;

[RemoteService(Name = SystemRemoteServiceConsts.RemoteServiceName)]
[Route("/api/system/ad")]
public class AdController : SystemController, IAdAppService
{
    private readonly IAdAppService _service;

    public AdController(IAdAppService service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("")]
        public virtual Task<AdDto> CreateAsync(AdCreateDto input)
    {
        return _service.CreateAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
        public virtual Task<AdDto> UpdateAsync(Guid id, AdUpdateDto input)
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
        public virtual Task<AdDto> GetAsync(Guid id)
    {
        return _service.GetAsync(id);
    }

    [HttpGet]
    [Route("")]
        public virtual Task<PagedResultDto<AdDto>> GetListAsync(AdGetListInput input)
    {
        return _service.GetListAsync(input);
    }
}