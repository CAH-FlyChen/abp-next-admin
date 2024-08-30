using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zion.Product.ProductContext.Dtos;
public class GetCategoryTreeResultItemDto
{
    public string Name { get; set; }
    public Guid Id { get; set; }
    public Guid? ParentId { get; set; }
    public List<GetCategoryTreeResultItemDto> Children { get; set; }
    public List<ProductSimpleDto> Products { get; set; }
    public string? ImageUrl { get; set; }
    public string? SpecTemplateJsonData { get; set; }
}
