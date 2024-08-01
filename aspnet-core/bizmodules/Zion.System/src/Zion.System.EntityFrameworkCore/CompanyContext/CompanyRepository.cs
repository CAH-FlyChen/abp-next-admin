using System;
using System.Linq;
using System.Threading.Tasks;
using Zion.System.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Zion.System.CompanyContext;

public class CompanyRepository : EfCoreRepository<ISystemDbContext, Company, Guid>, ICompanyRepository
{
    public CompanyRepository(IDbContextProvider<ISystemDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Company>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}