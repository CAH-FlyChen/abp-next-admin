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
/// 产品规格，和分类挂钩
/// </summary>
public class SpecificationTemplateBase : ValueObject
{
    public Guid Id { get; set; }
    public List<SpecificationGroup> SpecGroups { get; set; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        //foreach(var group in SpecGroups)
        //{
        //    yield return group.;
        //    foreach(var spec in group.Specifications)
        //    {
        //        yield return spec.Title;
        //        yield return spec.Options;
        //    }
        //}
        return null;
    }
}


