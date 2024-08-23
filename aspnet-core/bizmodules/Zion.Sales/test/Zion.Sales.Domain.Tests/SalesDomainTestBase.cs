using Volo.Abp.Modularity;

namespace Zion.Sales;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class SalesDomainTestBase<TStartupModule> : SalesTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
