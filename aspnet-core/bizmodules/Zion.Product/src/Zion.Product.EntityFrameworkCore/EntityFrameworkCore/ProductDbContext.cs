using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Specifications;

namespace Zion.Product.ProductContext.EntityFrameworkCore;

[ConnectionStringName(ProductDbProperties.ConnectionStringName)]
public class ProductDbContext : AbpDbContext<ProductDbContext>, IProductDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */
    public DbSet<Category> Categories { get; set; }
    /// <summary>
    /// 产品品牌
    /// </summary>
    public DbSet<Brand> Brands { get; set; }
    /// <summary>
    /// 产品单位
    /// </summary>
    public DbSet<Unit> Units { get; set; }
    public DbSet<Product> Products { get; set; }

    //public DbSet<CategorySpecTemplate> CategorySpecTemplates { get; set; }
    //public DbSet<ProductSpecTemplate> ProductSpecTemplates { get; set; }
    //public DbSet<SpecificationGroup> SpecificationGroups { get; set; }
    //public DbSet<SpecificationGroupItem> SpecificationGroupItems { get; set; }


    public ProductDbContext(DbContextOptions<ProductDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureProduct();
    }
}
