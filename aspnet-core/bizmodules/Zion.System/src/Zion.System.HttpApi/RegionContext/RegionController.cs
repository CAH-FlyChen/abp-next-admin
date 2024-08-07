using System;
using Zion.System.RegionContext.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Zion.System.RegionContext;

[RemoteService(Name = SystemRemoteServiceConsts.RemoteServiceName)]
[Route("/api/system/region")]
public class RegionController : SystemController, IRegionAppService
{
    private readonly IRegionAppService _service;

    public RegionController(IRegionAppService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("tree")]
    public virtual Task<List<GetTreeResultItemDto>> GetTree()
    {
        return _service.GetTree();
    }

    [HttpPost]
    [Route("")]
    public virtual Task<RegionDto> CreateAsync(RegionCreateDto input)
    {
        return _service.CreateAsync(input);
    }

    [HttpPut]
    [Route("{Code}")]
    public virtual Task<RegionDto> UpdateAsync(RegionKey id, RegionUpdateDto input)
    {
        return _service.UpdateAsync(id, input);
    }

    [HttpDelete]
    [Route("{Code}")]
    public virtual Task DeleteAsync(RegionKey id)
    {
        return _service.DeleteAsync(id);
    }

    [HttpGet]
    [Route("{Code}")]
    public virtual Task<RegionDto> GetAsync(RegionKey id)
    {
        return _service.GetAsync(id);
    }

    [HttpGet]
    [Route("")]
    public virtual Task<PagedResultDto<RegionDto>> GetListAsync(RegionGetListInput input)
    {
        return _service.GetListAsync(input);
    }
}