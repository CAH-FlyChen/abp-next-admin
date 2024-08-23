using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Zion.Sales.SalesContext;
public class ShoppingCartItem : Entity<Guid>
{
    public Guid ShoppingCartId { get; private set; }

    public string ProductId { get; private set; }

    public int Quantity { get; private set; }

    public decimal UnitPrice { get; private set; }

    public ShoppingCartItem(Guid id, string productId, int quantity, decimal unitPrice)
        :base(id)
    {
        Id = id;
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }


    public void ChangeQuantity(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("quantity不能小于等于0", "quantity");

        this.Quantity = quantity;
    }

    public void ChangeUnitPrice(decimal unitPrice)
    {
        if (unitPrice < 0)
            throw new ArgumentException("unitPrice不能小于0", "unitPrice");

        this.UnitPrice = unitPrice;
    }

    protected ShoppingCartItem()
    {
    }

    public ShoppingCartItem(
        Guid id,
        Guid shoppingCartId,
        string productId,
        int quantity,
        decimal unitPrice
    ) : base(id)
    {
        ShoppingCartId = shoppingCartId;
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}
