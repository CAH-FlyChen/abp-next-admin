using System;
using System.Linq;
using System.Threading.Tasks;
using Zion.Sales.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Zion.Sales.SalesContext;

public class ShoppingCartRepository : EfCoreRepository<ISalesDbContext, ShoppingCart, Guid>, IShoppingCartRepository
{
    public ShoppingCartRepository(IDbContextProvider<ISalesDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<ShoppingCart>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}