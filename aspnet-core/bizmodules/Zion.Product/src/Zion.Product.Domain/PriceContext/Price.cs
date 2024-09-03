using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Zion.System;

namespace Zion.Product.PriceContext;

public class Price : FullAuditedAggregateRoot<Guid>,IHasCompanyIdFilter
{
    public Guid ProductId { get; set; }
    public Guid? ProductSKUId { get; set; }
    /// <summary>
    /// 零售价
    /// </summary>
    public decimal PriceRetail { get; private set; }
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

    protected Price()
    {
    }

    public Price(
        Guid id,
        Guid productId,
        decimal priceRetail,
        decimal priceCombi,
        decimal priceCost,
        decimal price1,
        decimal price2,
        Guid companyId
    ) : base(id)
    {
        ProductId = productId;
        PriceRetail = priceRetail;
        PriceCombi = priceCombi;
        PriceCost = priceCost;
        Price1 = price1;
        Price2 = price2;
        CompanyId = companyId;
    }

}
