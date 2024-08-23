using System;
using Volo.Abp.Application.Dtos;

namespace Zion.System.AdContext.Dtos;

/// <summary>
/// 广告
/// </summary>
[Serializable]
public class AdDto : FullAuditedEntityDto<Guid>
{
    /// <summary>
    /// 广告名称 eg 首页barnner广告
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 图片地址
    /// </summary>
    public string ImageUrl { get; set; }

    /// <summary>
    /// 排序序号
    /// </summary>
    public int SortOrder { get; set; }

    /// <summary>
    /// 广告类型
    /// </summary>
    public string TypeCode { get; set; }

    /// <summary>
    /// 跳转地址
    /// </summary>
    public string TargetUrl { get; set; }

    /// <summary>
    /// 过期时间
    /// </summary>
    public DateTime? ExpDateTime { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; set; }
}