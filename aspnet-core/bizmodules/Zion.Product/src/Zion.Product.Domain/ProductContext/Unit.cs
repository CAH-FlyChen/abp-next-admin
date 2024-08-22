using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Zion.Product.ProductContext;
/// <summary>
/// 产品单位
/// </summary>
public class Unit:AggregateRoot<Guid>
{
    /// <summary>
    /// 名称
    /// </summary>
    [Required]
    [MaxLength(10)]
    public string Name { get; set; }

    protected Unit()
    {
    }

    public Unit(
        Guid id,
        string name
    ) : base(id)
    {
        Name = name;
    }
}
