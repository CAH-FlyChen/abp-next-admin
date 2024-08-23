using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Zion.Sales.SalesContext;

public static class ShoppingCartEfCoreQueryableExtensions
{
    public static IQueryable<ShoppingCart> IncludeDetails(this IQueryable<ShoppingCart> queryable, bool include = true)
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
