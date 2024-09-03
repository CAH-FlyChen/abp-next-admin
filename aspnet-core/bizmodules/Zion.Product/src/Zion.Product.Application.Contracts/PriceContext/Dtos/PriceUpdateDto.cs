using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Zion.Product.PriceContext.Dtos;

[Serializable]
public class PriceUpdateDto
{
    [DisplayName("PriceProductId")]
    public Guid ProductId { get; set; }
    public Guid? ProductSKUId { get; set; }
    /// <summary>
    /// 零售价
    /// </summary>
    [DisplayName("PricePriceRetail")]
    public decimal PriceRetail { get; set; }

    /// <summary>
    /// 批发价
    /// </summary>
    [DisplayName("PricePriceCombi")]
    public decimal PriceCombi { get; set; }

    /// <summary>
    /// 成本价
    /// </summary>
    [DisplayName("PricePriceCost")]
    public decimal PriceCost { get; set; }

    /// <summary>
    /// 价格1
    /// </summary>
    [DisplayName("PricePrice1")]
    public decimal Price1 { get; set; }

    /// <summary>
    /// 价格2
    /// </summary>
    [DisplayName("PricePrice2")]
    public decimal Price2 { get; set; }

    [DisplayName("PriceCompanyId")]
    public Guid CompanyId { get; set; }

}