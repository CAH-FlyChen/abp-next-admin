using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zion.Product.ProductContext;
public class ProductSkuDto
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    /// <summary>
    /// sku名称 默认为规格名称
    /// </summary>
    [MaxLength(2000)]
    public string? Name { get; set; }
    /// <summary>
    /// 规格名称，用于前台通过他查询skuid  md5(规则值1+规则值n) 规则值按照顺序排序
    /// eg  颜色|黄色,容量|125G
    /// </summary>
    [MaxLength(2000)]
    public string? PrivateSpecName { get; set; }
    /// <summary>
    /// eg   md5("颜色|黄色,容量|125G")
    /// </summary>
    [MaxLength(50)]
    public string? PrivateSpecNameMd5 { get; set; }
}
