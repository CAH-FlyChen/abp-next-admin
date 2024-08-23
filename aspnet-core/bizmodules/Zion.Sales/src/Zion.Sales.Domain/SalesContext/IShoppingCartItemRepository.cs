using System;
using Volo.Abp.Domain.Repositories;

namespace Zion.Sales.SalesContext;

public interface IShoppingCartItemRepository : IRepository<ShoppingCartItem, Guid>
{
}
