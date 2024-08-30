using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Values;

namespace Zion.Product.ProductContext;

/// <summary>
/// 产品规格，和分类挂钩基类
/// </summary>
public class SpecificationTemplate : ValueObject
{
    public Guid Id { get; set; }
    public List<SpecificationGroup> SpecGroups { get; set; }

    protected virtual IEnumerable<object> GetAtomicValuesInternal() { return null; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        return GetAtomicValuesInternal();
    }
}


