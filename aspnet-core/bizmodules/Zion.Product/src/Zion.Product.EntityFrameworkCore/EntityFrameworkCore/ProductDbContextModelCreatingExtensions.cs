using Zion.Product.ProductContext;
using Zion.Product;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Zion.Product.ProductContext.EntityFrameworkCore;

public static class ProductDbContextModelCreatingExtensions
{
    public static void ConfigureProduct(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(ProductDbProperties.DbTablePrefix + "Questions", ProductDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */


        builder.Entity<Category>(b =>
        {
            b.ToTable(ProductDbProperties.DbTablePrefix + "Categories", ProductDbProperties.DbSchema);
            b.ConfigureByConvention();

            //b.OwnsMany(t => t.CategorySpecTemplates, a =>
            //{
            //    a.OwnsOne(t => t.Category);

            //    a.OwnsMany(t => t.SpecGroups, b =>
            //    {
            //        b.OwnsOne(t => t.SpecificationTemplate);
            //        b.OwnsMany(t => t.Specifications, c =>
            //        {
            //            c.WithOwner().HasForeignKey(t => t.SpecificationGroupId);
            //        });
            //    });
            //});

            b.OwnsMany(t => t.SpecTemplates, a =>
            {
                a.WithOwner().HasForeignKey(t => t.CategoryId);
                a.OwnsMany(t => t.SpecGroups, b => {
                    b.WithOwner().HasForeignKey(t=>t.CategorySpecTemplateId);
                    b.OwnsMany(t => t.Specifications, c =>
                    {
                        c.WithOwner().HasForeignKey(t=>t.SpecificationGroupId);
                    });
                });
            });

            /* Configure more properties here */
        });


        builder.Entity<Brand>(b =>
        {
            b.ToTable(ProductDbProperties.DbTablePrefix + "Brands", ProductDbProperties.DbSchema, table => table.HasComment("产品品牌"));
            b.ConfigureByConvention(); 
            

            /* Configure more properties here */
        });


        builder.Entity<Unit>(b =>
        {
            b.ToTable(ProductDbProperties.DbTablePrefix + "Units", ProductDbProperties.DbSchema, table => table.HasComment("产品单位"));
            b.ConfigureByConvention(); 
            

            /* Configure more properties here */
        });


        builder.Entity<Product>(b =>
        {
            b.ToTable(ProductDbProperties.DbTablePrefix + "Products", ProductDbProperties.DbSchema);
            b.ConfigureByConvention();

            b.OwnsMany(t => t.SpecTemplates, a =>
            {
                a.WithOwner().HasForeignKey(t => t.ProductId);
                a.OwnsMany(t => t.SpecGroups, b => {
                    b.WithOwner().HasForeignKey(t => t.CategorySpecTemplateId);
                    b.OwnsMany(t => t.Specifications, c =>
                    {
                        c.WithOwner().HasForeignKey(t => t.SpecificationGroupId);
                    });
                });
            });
            /* Configure more properties here */
        });

        //builder.Entity<ProductSku>(b =>
        //{
        //    b.ToTable(ProductDbProperties.DbTablePrefix + "ProductSkus", ProductDbProperties.DbSchema);
        //});

    }
}
