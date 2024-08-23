using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Zion.Sales.SalesContext;

namespace Zion.Sales.EntityFrameworkCore;

[ConnectionStringName(SalesDbProperties.ConnectionStringName)]
public interface ISalesDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
    DbSet<ShoppingCart> ShoppingCarts { get; set; }
    DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
}
