using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace Zion.Sales.SalesContext.Dtos;

[Serializable]
public class ShoppingCartGetListInput : PagedAndSortedResultRequestDto
{
    [DisplayName("ShoppingCartCustomerId")]
    public Guid? CustomerId { get; set; }

}