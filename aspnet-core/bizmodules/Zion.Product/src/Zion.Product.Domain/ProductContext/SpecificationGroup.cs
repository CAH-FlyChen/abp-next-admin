using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Values;

namespace Zion.Product.ProductContext;
public class SpecificationGroup : ValueObject
{
    [Key]
    public Guid Id { get; set; }
    public Guid CategorySpecTemplateId { get; set; }
    public string Title { get; set; }
    public List<SpecificationGroupItem> Specifications { get; set; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Title;
        foreach (var item in Specifications)
        {
            yield return item.Title;
            foreach (var v in item.Options)
                yield return v;
        }

    }
}
