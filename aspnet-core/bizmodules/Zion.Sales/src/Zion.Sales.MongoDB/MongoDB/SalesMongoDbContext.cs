using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Zion.Sales.MongoDB;

[ConnectionStringName(SalesDbProperties.ConnectionStringName)]
public class SalesMongoDbContext : AbpMongoDbContext, ISalesMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureSales();
    }
}
