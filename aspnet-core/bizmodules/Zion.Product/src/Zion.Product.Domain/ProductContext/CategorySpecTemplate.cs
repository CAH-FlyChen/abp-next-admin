using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Values;

namespace Zion.Product.ProductContext;

public class CategorySpecTemplate : SpecificationTemplate
{
    [Key]
    public Guid Id { get; set;}

    public Guid? CategoryId { get; set; }

    //public List<SpecificationGroup> SpecGroups { get; set; }

    protected override IEnumerable<object> GetAtomicValuesInternal()
    {
        yield return CategoryId;
        foreach (var spec in SpecGroups)
        {
            yield return spec.Title;
            foreach (var item in spec.Specifications)
            {
                yield return item.Title;
                yield return item.Options;
            }
        }
    }
}
