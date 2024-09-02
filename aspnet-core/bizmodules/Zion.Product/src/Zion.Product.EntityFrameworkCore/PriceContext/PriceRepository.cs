using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Zion.Product.ProductContext.EntityFrameworkCore;

namespace Zion.Product.PriceContext;

public class PriceRepository : EfCoreRepository<IProductDbContext, Price, Guid>, IPriceRepository
{
    public PriceRepository(IDbContextProvider<IProductDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Price>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}