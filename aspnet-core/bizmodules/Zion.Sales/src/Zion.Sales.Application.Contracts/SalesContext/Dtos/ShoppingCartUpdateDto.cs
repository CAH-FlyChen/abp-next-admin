using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Zion.Sales.SalesContext.Dtos;

[Serializable]
public class ShoppingCartUpdateDto
{
    [DisplayName("ShoppingCartCustomerId")]
    public Guid CustomerId { get; set; }

    [DisplayName("ShoppingCartItems")]
    public List<ShoppingCartItemUpdateDto> Items { get; set; }
}