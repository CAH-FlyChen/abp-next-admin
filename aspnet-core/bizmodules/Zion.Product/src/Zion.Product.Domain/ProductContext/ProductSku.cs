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
    /// sku类型
    /// </summary>
    public Guid TypeId { get; set; }
    /// <summary>
    /// sku名称
    /// </summary>
    [MaxLength(100)]
    public string Name { get; set; }

    public virtual ProductSkuType Type { get; set; }

    public virtual Product Product { get; set; }
}
