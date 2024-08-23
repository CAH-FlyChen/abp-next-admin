using System;
using System.Linq;
using System.Threading.Tasks;
using Zion.System.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Zion.System.AdContext;

public class AdRepository : EfCoreRepository<ISystemDbContext, Ad, Guid>, IAdRepository
{
    public AdRepository(IDbContextProvider<ISystemDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Ad>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}