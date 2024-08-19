using System;
using System.Collections.Generic;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace Zion.Product.Dtos;

[Serializable]
public class CategoryGetListInput : PagedAndSortedResultRequestDto
{
    /// <summary>
    /// 名称
    /// </summary>
    [DisplayName("CategoryName")]
    public string? Name { get; set; }

    /// <summary>
    /// 等级
    /// </summary>
    [DisplayName("CategoryLevel")]
    public int? Level { get; set; }

    [DisplayName("CategoryParentId")]
    public Guid? ParentId { get; set; }

    /// <summary>
    /// 上级分类
    /// </summary>
    [DisplayName("CategoryParent")]
    public CategoryDto? Parent { get; set; }

    [DisplayName("CategoryChildren")]
    public ICollection<CategoryDto>? Children { get; set; }

    [DisplayName("CategoryDUId")]
    public Guid? DUId { get; set; }
}