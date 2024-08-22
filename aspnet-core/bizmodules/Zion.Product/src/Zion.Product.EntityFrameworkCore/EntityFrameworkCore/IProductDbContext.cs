using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Zion.Product;
using Zion.Product.ProductContext;

namespace Zion.Product.EntityFrameworkCore;

[ConnectionStringName(ProductDbProperties.ConnectionStringName)]
public interface IProductDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
    DbSet<Category> Categories { get; set; }
    /// <summary>
    /// 产品品牌
    /// </summary>
    DbSet<Brand> Brands { get; set; }
}
