using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Zion.System.AdContext;

/// <summary>
/// 广告
/// </summary>
public static class AdEfCoreQueryableExtensions
{
    public static IQueryable<Ad> IncludeDetails(this IQueryable<Ad> queryable, bool include = true)
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
