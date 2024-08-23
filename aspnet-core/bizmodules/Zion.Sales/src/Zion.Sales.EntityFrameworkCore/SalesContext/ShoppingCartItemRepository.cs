using System;
using System.Linq;
using System.Threading.Tasks;
using Zion.Sales.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Zion.Sales.SalesContext;

public class ShoppingCartItemRepository : EfCoreRepository<ISalesDbContext, ShoppingCartItem, Guid>, IShoppingCartItemRepository
{
    public ShoppingCartItemRepository(IDbContextProvider<ISalesDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<ShoppingCartItem>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}