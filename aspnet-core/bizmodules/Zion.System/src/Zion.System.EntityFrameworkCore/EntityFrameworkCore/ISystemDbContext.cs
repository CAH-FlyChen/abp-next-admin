using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Zion.System.CompanyContext;
using Zion.System.RegionContext;

namespace Zion.System.EntityFrameworkCore;

[ConnectionStringName(SystemDbProperties.ConnectionStringName)]
public interface ISystemDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
    DbSet<Company> Companies { get; set; }
    /// <summary>
    /// 行政区域
    /// </summary>
    DbSet<Region> Regions { get; set; }
}
