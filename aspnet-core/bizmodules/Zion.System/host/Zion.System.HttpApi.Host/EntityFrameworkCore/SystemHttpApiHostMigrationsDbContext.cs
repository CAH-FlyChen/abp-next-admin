using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Zion.System.EntityFrameworkCore;

public class SystemHttpApiHostMigrationsDbContext : AbpDbContext<SystemHttpApiHostMigrationsDbContext>
{
    public SystemHttpApiHostMigrationsDbContext(DbContextOptions<SystemHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureSystem();
    }
}
