using System;
using System.ComponentModel;

namespace Zion.Product.ProductContext.Dtos;

[Serializable]
public class UnitCreateDto
{
    /// <summary>
    /// 名称
    /// </summary>
    [DisplayName("UnitName")]
    public string Name { get; set; }
}