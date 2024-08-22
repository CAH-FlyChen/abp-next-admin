using System;
using Volo.Abp.Application.Dtos;

namespace Zion.Product.ProductContext.Dtos;

/// <summary>
/// 产品单位
/// </summary>
[Serializable]
public class UnitDto : EntityDto<Guid>
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }
}