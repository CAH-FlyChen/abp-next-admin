using System;
using Volo.Abp.Application.Dtos;

namespace Zion.System.RegionContext.Dtos;

/// <summary>
/// 行政区域
/// </summary>
[Serializable]
public class RegionDto : FullAuditedEntityDto
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
    public string ParentCode { get; set; }

    /// <summary>
    /// 类型 区域类型，国家 0，省 1，市 2，区县 3
    /// </summary>
    public RegionType RegionTypeCode { get; set; }
}