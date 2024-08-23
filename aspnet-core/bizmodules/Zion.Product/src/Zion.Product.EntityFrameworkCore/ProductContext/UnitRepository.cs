using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Zion.Product.ProductContext.EntityFrameworkCore;

namespace Zion.Product.ProductContext;

public class UnitRepository : EfCoreRepository<IProductDbContext, Unit, Guid>, IUnitRepository
{
    public UnitRepository(IDbContextProvider<IProductDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Unit>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}