using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq.Expressions;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;
using Volo.Abp.EntityFrameworkCore;
using Zion.System.CompanyContext;

namespace Zion.System.EntityFrameworkCore;

[ConnectionStringName(SystemDbProperties.ConnectionStringName)]
public class SystemDbContext : ZionDbContext<SystemDbContext>, ISystemDbContext
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
