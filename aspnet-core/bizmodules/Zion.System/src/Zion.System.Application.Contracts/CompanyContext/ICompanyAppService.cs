using System;
using Zion.System.CompanyContext.Dtos;
using Volo.Abp.Application.Services;

namespace Zion.System.CompanyContext;


public interface ICompanyAppService :
    ICrudAppService< 
        CompanyDto, 
        Guid, 
        CompanyGetListInput,
        CompanyCreateDto,
        CompanyUpdateDto>
{

}