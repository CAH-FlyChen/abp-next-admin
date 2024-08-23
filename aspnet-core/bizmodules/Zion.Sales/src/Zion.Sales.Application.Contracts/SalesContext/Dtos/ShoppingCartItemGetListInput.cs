using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace Zion.Sales.SalesContext.Dtos;

[Serializable]
public class ShoppingCartItemGetListInput : PagedAndSortedResultRequestDto
{
    [DisplayName("ShoppingCartItemShoppingCartId")]
    public Guid? ShoppingCartId { get; set; }

    [DisplayName("ShoppingCartItemProductId")]
    public string? ProductId { get; set; }

    [DisplayName("ShoppingCartItemQuantity")]
    public int? Quantity { get; set; }

    [DisplayName("ShoppingCartItemUnitPrice")]
    public decimal? UnitPrice { get; set; }
}