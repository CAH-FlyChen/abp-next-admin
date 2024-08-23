using System;
using System.ComponentModel;

namespace Zion.System.AdContext.Dtos;

[Serializable]
public class AdCreateDto
{
    /// <summary>
    /// 广告名称 eg 首页barnner广告
    /// </summary>
    [DisplayName("AdName")]
    public string Name { get; set; }

    /// <summary>
    /// 图片地址
    /// </summary>
    [DisplayName("AdImageUrl")]
    public string ImageUrl { get; set; }

    /// <summary>
    /// 排序序号
    /// </summary>
    [DisplayName("AdSortOrder")]
    public int SortOrder { get; set; }

    /// <summary>
    /// 广告类型
    /// </summary>
    [DisplayName("AdTypeCode")]
    public string TypeCode { get; set; }

    /// <summary>
    /// 跳转地址
    /// </summary>
    [DisplayName("AdTargetUrl")]
    public string TargetUrl { get; set; }

    /// <summary>
    /// 过期时间
    /// </summary>
    [DisplayName("AdExpDateTime")]
    public DateTime? ExpDateTime { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    [DisplayName("AdDescription")]
    public string Description { get; set; }
}