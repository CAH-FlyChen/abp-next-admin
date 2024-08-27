using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Values;

namespace Zion.Product.ProductContext;
public class ProductSpecTemplate : ValueObject
{
    [Key]
    public Guid Id { get; set; }

    public Guid? ProductId { get; set; }

    public List<SpecificationGroup> SpecGroups { get; set; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return ProductId!;
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
