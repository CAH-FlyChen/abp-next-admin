using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Zion.Sales.SalesContext.Dtos;

[Serializable]
public class ShoppingCartCreateDto
{
    [DisplayName("ShoppingCartCustomerId")]
    public Guid CustomerId { get; set; }

    [DisplayName("ShoppingCartItems")]
    public List<ShoppingCartItemCreateDto> Items { get; set; }
}