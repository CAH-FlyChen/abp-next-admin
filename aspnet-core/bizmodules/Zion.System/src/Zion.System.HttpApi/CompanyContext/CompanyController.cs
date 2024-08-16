using System;
using Zion.System.CompanyContext.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Zion.System.CompanyContext;

[RemoteService(Name = SystemRemoteServiceConsts.RemoteServiceName)]
[Route("/api/system/company")]
public class CompanyController : SystemController, ICompanyAppService
{
    private readonly ICompanyAppService _service;

    public CompanyController(ICompanyAppService service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("")]
        public virtual Task<CompanyDto> CreateAsync(CompanyCreateDto input)
    {
        return _service.CreateAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
        public virtual Task<CompanyDto> UpdateAsync(Guid id, CompanyUpdateDto input)
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
        public virtual Task<CompanyDto> GetAsync(Guid id)
    {
        return _service.GetAsync(id);
    }

    [HttpGet]
    [Route("")]
        public virtual Task<PagedResultDto<CompanyDto>> GetListAsync(CompanyGetListInput input)
    {
        return _service.GetListAsync(input);
    }
}