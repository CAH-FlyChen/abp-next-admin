using System;
using Volo.Abp.Domain.Repositories;

namespace Zion.Product;

public interface ICategoryRepository : IRepository<Category, Guid>
{
}
