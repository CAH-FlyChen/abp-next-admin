using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zion.Product.ProductContext;

public class CategorySpecTemplate : SpecificationTemplate
{
    public Guid? CategoryId { get; set; }
    public virtual Category Category { get; set; }

    protected override IEnumerable<object> GetAtomicValuesImp()
    {
        yield return CategoryId!;
        yield return SpecGroups;
    }
}
