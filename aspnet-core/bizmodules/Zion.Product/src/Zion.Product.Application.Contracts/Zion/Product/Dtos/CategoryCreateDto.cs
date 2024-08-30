using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Zion.Product.Dtos;

[Serializable]
public class CategoryCreateDto
{
    /// <summary>
    /// 名称
    /// </summary>
    [DisplayName("CategoryName")]
    public string Name { get; set; }

    /// <summary>
    /// 等级
    /// </summary>
    [DisplayName("CategoryLevel")]
    public int Level { get; set; }

    [DisplayName("CategoryParentId")]
    public Guid? ParentId { get; set; }

    [MaxLength(4000)]
    public string? ImageUrl { get; set; }

    public string? SpecTemplateJsonData { get; set; }

    [DisplayName("CategoryChildren")]
    public ICollection<CategoryCreateDto>? Children { get; set; }
}