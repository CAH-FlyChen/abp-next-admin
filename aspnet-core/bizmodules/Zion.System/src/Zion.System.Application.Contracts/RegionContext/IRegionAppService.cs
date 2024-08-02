using System;
using Zion.System.RegionContext.Dtos;
using Volo.Abp.Application.Services;

namespace Zion.System.RegionContext;


/// <summary>
/// 行政区域
/// </summary>
public interface IRegionAppService :
    ICrudAppService< 
                RegionDto, 
        RegionKey, 
        RegionGetListInput,
        RegionCreateDto,
        RegionUpdateDto>
{

}