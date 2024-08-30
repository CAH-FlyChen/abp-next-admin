using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zion.Product.ProductContext.Dtos;

public class CategorySpecTemplateDto
{
    public Guid Id { get; set; }

    public Guid? CategoryId { get; set; }

    public List<SpecificationGroupDto> SpecGroups { get; set; }
}

public class SpecificationGroupDto
{
    public Guid Id { get; set; }
    public Guid CategorySpecTemplateId { get; set; }
    public string Title { get; set; }
    public List<SpecificationGroupItemDto> Specifications { get; set; }
}

public class SpecificationGroupItemDto
{
    public Guid Id { get; set; }
    public Guid SpecificationGroupId { get; set; }
    public bool IsGlobal { get; set; }
    public string Title { get; set; }
    public SpecificationGroupItemOptionDto[] Options { get; set; }
}

public class SpecificationGroupItemOptionDto
{
    public string Title { get; set; }
    public bool IsSelected { get; set; }
}
