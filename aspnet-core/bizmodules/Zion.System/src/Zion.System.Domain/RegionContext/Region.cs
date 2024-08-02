using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Zion.System.RegionContext;
/// <summary>
/// 行政区域
/// </summary>
public class Region : FullAuditedAggregateRoot
{
    /// <summary>
    /// 行政区域代码
    /// </summary>
    [MaxLength(10)]
    [Required]
    [Key]
    [Description("行政区域代码")]
    public string Code { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    [MaxLength(50)]
    [Required]
    [Description("行政区域名称")]
    public string Name { get; set; }

    /// <summary>
    /// 上级Code
    /// </summary>
    [Description("上级Code")]
    [MaxLength(10)]
    public string ParentCode { get; set; }

    /// <summary>
    /// 类型 区域类型，国家 0，省 1，市 2，区县 3
    /// </summary>
    [Description("区域类型，国家 0，省 1，市 2，区县 3")]
    public RegionType ReginTypeCode { get; set; }

    public override object[] GetKeys()
    {
        return new object[] { Code };
    }

    protected Region()
    {
    }

    public Region(
        string code,
        string name,
        string parentCode,
        RegionType reginTypeCode
    )
    {
        Code = code;
        Name = name;
        ParentCode = parentCode;
        ReginTypeCode = reginTypeCode;
    }
}
