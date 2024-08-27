using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Values;

namespace Zion.Product.ProductContext;

public class ProductSkuSpecValue
{
    public string GroupTitle { get; set; }
    public List<ProductSkuSpecValueItem> Items { get; set; }

    //protected override IEnumerable<object> GetAtomicValues()
    //{
    //    yield return new object[] { GroupTitle, Items };
    //}
}

public class ProductSkuSpecValueItem
{
    public string K { get; set; }
    public string V { get; set; }
}
