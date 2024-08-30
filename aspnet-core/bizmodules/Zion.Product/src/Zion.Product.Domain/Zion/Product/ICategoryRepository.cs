using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Zion.Product.ProductContext;

public interface ICategoryRepository : IRepository<Category, Guid>
{
    //Task<IQueryable<Category>> WithSpecAsync();
}
