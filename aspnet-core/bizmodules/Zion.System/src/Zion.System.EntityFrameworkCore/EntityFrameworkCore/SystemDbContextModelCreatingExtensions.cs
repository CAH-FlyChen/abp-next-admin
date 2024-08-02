using Zion.System.RegionContext;
using Zion.System.CompanyContext;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Zion.System.EntityFrameworkCore;

public static class SystemDbContextModelCreatingExtensions
{
    public static void ConfigureSystem(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(SystemDbProperties.DbTablePrefix + "Questions", SystemDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */


        builder.Entity<Company>(b =>
        {
            b.ToTable(SystemDbProperties.DbTablePrefix + "Companies", SystemDbProperties.DbSchema);
            b.OwnsOne(t => t.CompanyLocation);
            b.ConfigureByConvention(); 
            

            /* Configure more properties here */
        });

        builder.Entity<CompanyUser>(b =>
        {
            b.ToTable(SystemDbProperties.DbTablePrefix + "CompanyUsers", SystemDbProperties.DbSchema);
            b.ConfigureByConvention();
            b.HasKey(c => new { c.CompanyId, c.UserId });
            /* Configure more properties here */
        });


        builder.Entity<Region>(b =>
        {
            b.ToTable(SystemDbProperties.DbTablePrefix + "Regions", SystemDbProperties.DbSchema, table => table.HasComment("行政区域"));
            b.ConfigureByConvention(); 
            
            b.HasKey(e => new
            {
                e.Code,
            });

            /* Configure more properties here */
        });
    }
}
