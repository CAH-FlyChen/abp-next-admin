using Zion.Sales.SalesContext;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Zion.Sales.EntityFrameworkCore;

public static class SalesDbContextModelCreatingExtensions
{
    public static void ConfigureSales(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(SalesDbProperties.DbTablePrefix + "Questions", SalesDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */


        builder.Entity<ShoppingCart>(b =>
        {
            b.ToTable(SalesDbProperties.DbTablePrefix + "ShoppingCarts", SalesDbProperties.DbSchema);
            b.ConfigureByConvention(); 
            

            /* Configure more properties here */
        });


        builder.Entity<ShoppingCartItem>(b =>
        {
            b.ToTable(SalesDbProperties.DbTablePrefix + "ShoppingCartItems", SalesDbProperties.DbSchema);
            b.ConfigureByConvention(); 
            

            /* Configure more properties here */
        });
    }
}
