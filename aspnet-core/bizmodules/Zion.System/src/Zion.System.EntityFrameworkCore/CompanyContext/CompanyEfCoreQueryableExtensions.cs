using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Zion.System.CompanyContext;

public static class CompanyEfCoreQueryableExtensions
{
    public static IQueryable<Company> IncludeDetails(this IQueryable<Company> queryable, bool include = true)
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
