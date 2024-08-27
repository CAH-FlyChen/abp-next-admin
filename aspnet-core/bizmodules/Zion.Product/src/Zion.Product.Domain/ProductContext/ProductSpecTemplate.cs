using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zion.Product.ProductContext;
public class ProductSpecTemplate : SpecificationTemplate
{
    public Guid ProductId { get; set; }

    protected override IEnumerable<object> GetAtomicValuesImp()
    {
        yield return ProductId;
        yield return SpecGroups;
    }
}
