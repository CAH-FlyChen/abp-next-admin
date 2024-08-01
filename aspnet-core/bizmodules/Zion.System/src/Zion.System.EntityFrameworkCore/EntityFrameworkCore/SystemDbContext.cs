using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Zion.System.CompanyContext;

namespace Zion.System.EntityFrameworkCore;

[ConnectionStringName(SystemDbProperties.ConnectionStringName)]
public class SystemDbContext : AbpDbContext<SystemDbContext>, ISystemDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */
    public DbSet<Company> Companies { get; set; }

    public SystemDbContext(DbContextOptions<SystemDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureSystem();
    }
}
