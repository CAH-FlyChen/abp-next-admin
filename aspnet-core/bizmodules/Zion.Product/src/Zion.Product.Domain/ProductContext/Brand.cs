using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Zion.Product.ProductContext;

public class Brand : FullAuditedAggregateRoot<Guid>
{
    /// <summary>
    /// 品牌名称
    /// </summary>
    [Required(ErrorMessage = "品牌名称不能为空")]
    [MaxLength(100)]
    public string Name { get; set; }
    /// <summary>
    /// 简拼
    /// </summary>
    [Required(ErrorMessage = "简拼不能为空")]
    [MaxLength(10)]
    public string JP { get; set; }
    /// <summary>
    /// 首字母
    /// </summary>
    [Required(ErrorMessage = "首字母不能为空")]
    [MaxLength(1)]
    public string InitialChar { get; set; }
    /// <summary>
    /// 品牌图片地址
    /// </summary>
    [MaxLength(2000)]
    public string? ImgUrl { get; set; }
}
