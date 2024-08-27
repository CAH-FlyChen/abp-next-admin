using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zion.Product.ProductContext.Dtos;
public class CategorySimpleDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public class CategoryListDto
{
    public List<CategorySimpleDto> Categories { get; set; }
}
