using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Values;

namespace Zion.Product.ProductContext;

public class ProductSkuSpecValue : ValueObject
{
    public string GroupTitle { get; set; }
    public Dictionary<string, string> Items { get; set; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return new object[] { GroupTitle, Items };
    }
}
