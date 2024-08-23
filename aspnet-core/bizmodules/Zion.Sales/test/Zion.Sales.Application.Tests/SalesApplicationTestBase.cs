using Volo.Abp.Modularity;

namespace Zion.Sales;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class SalesApplicationTestBase<TStartupModule> : SalesTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
