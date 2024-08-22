using System;
using Volo.Abp.Domain.Repositories;

namespace Zion.Product.ProductContext;

public interface ICategoryRepository : IRepository<Category, Guid>
{
}
