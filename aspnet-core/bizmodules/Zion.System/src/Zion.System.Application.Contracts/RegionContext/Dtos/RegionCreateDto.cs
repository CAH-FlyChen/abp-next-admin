using System;
using System.ComponentModel;

namespace Zion.System.RegionContext.Dtos;

[Serializable]
public class RegionCreateDto
{
    /// <summary>
    /// 行政区域代码
    /// </summary>
    [DisplayName("RegionCode")]
    public string Code { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    [DisplayName("RegionName")]
    public string Name { get; set; }

    /// <summary>
    /// 上级Code
    /// </summary>
    [DisplayName("RegionParentCode")]
    public string? ParentCode { get; set; }

    /// <summary>
    /// 类型 区域类型，国家 0，省 1，市 2，区县 3
    /// </summary>
    [DisplayName("RegionReginTypeCode")]
    public RegionType RegionTypeCode { get; set; }
}