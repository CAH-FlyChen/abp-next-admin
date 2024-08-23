using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Zion.Product.ProductContext.EntityFrameworkCore;

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
    /// <summary>
    /// 产品单位
    /// </summary>
    DbSet<Unit> Units { get; set; }
    DbSet<Product> Products { get; set; }
}
