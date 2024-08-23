using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Zion.System.AdContext;
/// <summary>
/// 广告
/// </summary>
public class Ad : FullAuditedAggregateRoot<Guid>
{
    /// <summary>
    /// 广告名称 eg 首页barnner广告
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 图片地址
    /// </summary>
    [Required]
    [MaxLength(2000)]
    public string ImageUrl { get; set; }
    /// <summary>
    /// 排序序号
    /// </summary>
    public int SortOrder { get; set; }
    /// <summary>
    /// 广告类型
    /// </summary>
    [Required]
    [MaxLength(20)]
    public string TypeCode { get; set; }
    /// <summary>
    /// 跳转地址
    /// </summary>
    [Required]
    [MaxLength(2000)]
    public string TargetUrl { get; set; }
    /// <summary>
    /// 过期时间
    /// </summary>
    public DateTime? ExpDateTime { get; set; }
    /// <summary>
    /// 描述
    /// </summary>
    [MaxLength(2000)]
    public string Description { get; set; }

    protected Ad()
    {
    }

    public Ad(
        Guid id,
        string name,
        string imageUrl,
        int sortOrder,
        string typeCode,
        string targetUrl,
        DateTime? expDateTime,
        string description
    ) : base(id)
    {
        Name = name;
        ImageUrl = imageUrl;
        SortOrder = sortOrder;
        TypeCode = typeCode;
        TargetUrl = targetUrl;
        ExpDateTime = expDateTime;
        Description = description;
    }
}
