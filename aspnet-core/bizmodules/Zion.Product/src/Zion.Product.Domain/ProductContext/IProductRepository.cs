using System;
using Volo.Abp.Domain.Repositories;

namespace Zion.Product.ProductContext;

public interface IProductRepository : IRepository<Product, Guid>
{
}
