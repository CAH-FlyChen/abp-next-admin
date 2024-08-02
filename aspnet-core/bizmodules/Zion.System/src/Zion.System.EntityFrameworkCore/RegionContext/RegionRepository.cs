using System;
using System.Linq;
using System.Threading.Tasks;
using Zion.System.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Zion.System.RegionContext;

public class RegionRepository : EfCoreRepository<ISystemDbContext, Region>, IRegionRepository
{
    public RegionRepository(IDbContextProvider<ISystemDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Region>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}