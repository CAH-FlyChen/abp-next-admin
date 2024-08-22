using System;
using System.ComponentModel;

namespace Zion.Product.ProductContext.Dtos;

/// <summary>
/// 产品单位
/// </summary>
[Serializable]
public class UnitUpdateDto
{
    /// <summary>
    /// 名称
    /// </summary>
    [DisplayName("UnitName")]
    public string Name { get; set; }
}