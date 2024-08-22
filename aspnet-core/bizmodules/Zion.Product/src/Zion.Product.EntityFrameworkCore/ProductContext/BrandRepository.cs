using System;
using System.Linq;
using System.Threading.Tasks;
using Zion.Product.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Zion.Product.ProductContext;

public class BrandRepository : EfCoreRepository<IProductDbContext, Brand, Guid>, IBrandRepository
{
    public BrandRepository(IDbContextProvider<IProductDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Brand>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}