using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Zion.System.RegionContext;

/// <summary>
/// 行政区域
/// </summary>
public static class RegionEfCoreQueryableExtensions
{
    public static IQueryable<Region> IncludeDetails(this IQueryable<Region> queryable, bool include = true)
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
