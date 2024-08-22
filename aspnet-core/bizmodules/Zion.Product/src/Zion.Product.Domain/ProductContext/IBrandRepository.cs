using System;
using Volo.Abp.Domain.Repositories;

namespace Zion.Product.ProductContext;

/// <summary>
/// 产品品牌
/// </summary>
public interface IBrandRepository : IRepository<Brand, Guid>
{
}
