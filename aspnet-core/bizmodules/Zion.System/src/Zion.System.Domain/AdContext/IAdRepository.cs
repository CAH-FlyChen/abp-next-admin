using System;
using Volo.Abp.Domain.Repositories;

namespace Zion.System.AdContext;

/// <summary>
/// 广告
/// </summary>
public interface IAdRepository : IRepository<Ad, Guid>
{
}
