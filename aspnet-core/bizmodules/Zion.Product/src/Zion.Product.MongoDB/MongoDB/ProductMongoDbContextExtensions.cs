using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Zion.Product.MongoDB;

public static class ProductMongoDbContextExtensions
{
    public static void ConfigureProduct(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
