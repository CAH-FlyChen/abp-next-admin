using System;
using Zion.System.RegionContext.Dtos;
using Volo.Abp.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Zion.System.RegionContext;

public class GetTreeResultItemDto
{
    /// <summary>
    /// 行政区域代码
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 上级Code
    /// </summary>
    public string? ParentCode { get; set; }

    /// <summary>
    /// 类型 区域类型，国家 0，省 1，市 2，区县 3
    /// </summary>
    public RegionType RegionTypeCode { get; set; }

    public List<GetTreeResultItemDto> Children { get; set; }
}

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
    Task<List<GetTreeResultItemDto>> GetTree();
}