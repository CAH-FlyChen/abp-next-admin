using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Zion.Product.StockContext;

public class Stock : FullAuditedAggregateRoot<Guid>
{
    public Guid SkuId { get; set; }
    public Guid ProductId { get; set; }
    public int Qty { get; set; }
}
