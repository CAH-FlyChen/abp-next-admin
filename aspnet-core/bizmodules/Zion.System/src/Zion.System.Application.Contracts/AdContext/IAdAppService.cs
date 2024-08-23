using System;
using Zion.System.AdContext.Dtos;
using Volo.Abp.Application.Services;

namespace Zion.System.AdContext;


/// <summary>
/// 广告
/// </summary>
public interface IAdAppService :
    ICrudAppService< 
                AdDto, 
        Guid, 
        AdGetListInput,
        AdCreateDto,
        AdUpdateDto>
{

}