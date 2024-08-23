using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Guids;

namespace Zion.Sales.SalesContext;

public class ShoppingCart : FullAuditedAggregateRoot<Guid>
{
    public Guid CustomerId { get; private set; }

    public virtual List<ShoppingCartItem> Items { get; private set; }

    protected ShoppingCart()
    {
    }

    public ShoppingCart(
        Guid id,
        Guid customerId
    ) : base(id)
    {
        CustomerId = customerId;
        Items = new List<ShoppingCartItem>();
    }

    public void AddCartItem(string productId, int quantity, decimal price)
    {
        var cartItem = new ShoppingCartItem(SimpleGuidGenerator.Instance.Create(),productId, quantity, price);
        var existedCartItem = Items.SingleOrDefault(ent => ent.ProductId == cartItem.ProductId);
        if (existedCartItem == null)
        {
            Items.Add(cartItem);
        }
        else
        {
            existedCartItem.ChangeUnitPrice(cartItem.UnitPrice); //有可能价格更新了，每次都更新一下。
            existedCartItem.ChangeQuantity(existedCartItem.Quantity + cartItem.Quantity);
        }
    }

    public ReadOnlyCollection<ShoppingCartItem> GetCartItems()
    {
        return this.Items.AsReadOnly();
    }


    public bool IsEmpty()
    {
        return this.Items.Count == 0;
    }

    public int TotalItemCount()
    {
        return this.Items.Count;
    }

    public int TotalItemNum()
    {
        if (this.Items.Count == 0)
            return 0;
        return this.Items.Sum(e => e.Quantity);
    }
}
