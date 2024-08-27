using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Zion.Product.ProductContext;
/// <summary>
/// sku 类型 例如：颜色，容量等
/// </summary>
public class ProductSkuType : Entity<Guid>
{
    [MaxLength(50)]
    public string Name { get; set; }
}
