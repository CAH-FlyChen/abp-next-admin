using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Zion.Product.Dtos;

[Serializable]
public class CategoryDto : FullAuditedEntityDto<Guid>
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 等级
    /// </summary>
    public int Level { get; set; }

    public Guid? ParentId { get; set; }

    /// <summary>
    /// 上级分类
    /// </summary>
    public CategoryDto? Parent { get; set; }

    public ICollection<CategoryDto>? Children { get; set; }

}