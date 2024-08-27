using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zion.Product.ProductContext;
public class SpecificationGroup
{
    public string Title { get; set; }
    public List<SpecificationGroupItem> Specifications { get; set; }
}
