using System;
using Volo.Abp.Domain.Repositories;

namespace Zion.Product.ProductContext;

/// <summary>
/// 产品单位
/// </summary>
public interface IUnitRepository : IRepository<Unit, Guid>
{
}
