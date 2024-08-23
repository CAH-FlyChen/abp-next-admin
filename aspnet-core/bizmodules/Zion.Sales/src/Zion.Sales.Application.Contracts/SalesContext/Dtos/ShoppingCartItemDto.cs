using System;
using Volo.Abp.Application.Dtos;

namespace Zion.Sales.SalesContext.Dtos;

[Serializable]
public class ShoppingCartItemDto : EntityDto<Guid>
{
    public Guid ShoppingCartId { get; set; }

    public string ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }
}