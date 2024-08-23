using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Zion.Sales.SalesContext.Dtos;

[Serializable]
public class ShoppingCartDto : FullAuditedEntityDto<Guid>
{
    public Guid CustomerId { get; set; }

    public List<ShoppingCartItemDto> Items { get; set; }
}