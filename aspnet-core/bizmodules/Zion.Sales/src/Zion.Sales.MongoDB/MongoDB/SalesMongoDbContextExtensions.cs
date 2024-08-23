using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Zion.Sales.MongoDB;

public static class SalesMongoDbContextExtensions
{
    public static void ConfigureSales(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
