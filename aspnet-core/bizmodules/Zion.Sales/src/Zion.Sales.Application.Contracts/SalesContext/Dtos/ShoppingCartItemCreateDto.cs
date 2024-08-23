using System;
using System.ComponentModel;

namespace Zion.Sales.SalesContext.Dtos;

[Serializable]
public class ShoppingCartItemCreateDto
{
    [DisplayName("ShoppingCartItemShoppingCartId")]
    public Guid ShoppingCartId { get; set; }

    [DisplayName("ShoppingCartItemProductId")]
    public string ProductId { get; set; }

    [DisplayName("ShoppingCartItemQuantity")]
    public int Quantity { get; set; }

    [DisplayName("ShoppingCartItemUnitPrice")]
    public decimal UnitPrice { get; set; }
}