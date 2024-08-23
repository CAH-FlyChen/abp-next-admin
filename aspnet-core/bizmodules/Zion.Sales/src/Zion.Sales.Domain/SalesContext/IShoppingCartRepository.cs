using System;
using Volo.Abp.Domain.Repositories;

namespace Zion.Sales.SalesContext;

public interface IShoppingCartRepository : IRepository<ShoppingCart, Guid>
{
}
