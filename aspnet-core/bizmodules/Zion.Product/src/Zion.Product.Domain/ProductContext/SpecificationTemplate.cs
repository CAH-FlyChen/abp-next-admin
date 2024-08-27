using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Values;

namespace Zion.Product.ProductContext;

/// <summary>
/// 产品规格，和分类挂钩
/// </summary>
public abstract class SpecificationTemplate : ValueObject
{
    public List<SpecificationGroup> SpecGroups { get; set; }

    protected abstract IEnumerable<object> GetAtomicValuesImp();

    protected override IEnumerable<object> GetAtomicValues()
    {
        return GetAtomicValuesImp();
    }
}


