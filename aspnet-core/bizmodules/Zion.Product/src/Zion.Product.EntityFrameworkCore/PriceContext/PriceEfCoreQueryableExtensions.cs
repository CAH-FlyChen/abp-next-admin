using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Zion.Product.PriceContext;

public static class PriceEfCoreQueryableExtensions
{
    public static IQueryable<Price> IncludeDetails(this IQueryable<Price> queryable, bool include = true)
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
