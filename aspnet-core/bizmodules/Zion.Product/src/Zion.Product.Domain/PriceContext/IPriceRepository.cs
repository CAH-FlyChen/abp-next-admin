using System;
using Volo.Abp.Domain.Repositories;

namespace Zion.Product.PriceContext;

public interface IPriceRepository : IRepository<Price, Guid>
{
}
