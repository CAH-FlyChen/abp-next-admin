using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Zion.Product.ProductContext.EntityFrameworkCore;

namespace Zion.Product.ProductContext;

public class CategoryRepository : EfCoreRepository<IProductDbContext, Category, Guid>, ICategoryRepository
{
    public CategoryRepository(IDbContextProvider<IProductDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Category>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}