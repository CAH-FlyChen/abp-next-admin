using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Zion.Product.PriceContext.Dtos;

[Serializable]
public class PriceDto : FullAuditedEntityDto<Guid>
{
    public Guid ProductId { get; set; }

    /// <summary>
    /// 零售价
    /// </summary>
    public decimal PriceRetail { get; set; }

    /// <summary>
    /// 批发价
    /// </summary>
    public decimal PriceCombi { get; set; }

    /// <summary>
    /// 成本价
    /// </summary>
    public decimal PriceCost { get; set; }

    /// <summary>
    /// 价格1
    /// </summary>
    public decimal Price1 { get; set; }

    /// <summary>
    /// 价格2
    /// </summary>
    public decimal Price2 { get; set; }

    public Guid CompanyId { get; set; }
}