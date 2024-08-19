using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Zion.Product.Dtos;

[Serializable]
public class CategoryUpdateDto
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

}