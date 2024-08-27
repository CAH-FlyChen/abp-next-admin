using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Zion.Product.ProductContext;
public class ProductSku : Entity<Guid>
{
    public Guid ProductId { get; set; }

    /// <summary>
    /// sku名称
    /// </summary>
    [MaxLength(100)]
    public string Name { get; set; }

    /// <summary>
    /// 产品设定的规格键值对
    /// </summary>
    public ProductSkuSpecValue ProductSkuSpec { get; set; }

    public virtual Product Product { get; set; }
}
