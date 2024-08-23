using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Zion.Sales.SalesContext;

public static class ShoppingCartItemEfCoreQueryableExtensions
{
    public static IQueryable<ShoppingCartItem> IncludeDetails(this IQueryable<ShoppingCartItem> queryable, bool include = true)
    {
        if (!include)
        {
            return queryable;
        }

        return queryable
            // .Include(x => x.xxx) // TODO: AbpHelper generated
            ;
    }
}
