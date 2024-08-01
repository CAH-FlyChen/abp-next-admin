using Volo.Abp.Modularity;

namespace Zion.System;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class SystemApplicationTestBase<TStartupModule> : SystemTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
