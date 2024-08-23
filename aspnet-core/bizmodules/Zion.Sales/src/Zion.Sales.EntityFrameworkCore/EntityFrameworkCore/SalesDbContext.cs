using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Zion.Sales.SalesContext;

namespace Zion.Sales.EntityFrameworkCore;

[ConnectionStringName(SalesDbProperties.ConnectionStringName)]
public class SalesDbContext : AbpDbContext<SalesDbContext>, ISalesDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    public SalesDbContext(DbContextOptions<SalesDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureSales();
    }
}
