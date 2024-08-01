using Volo.Abp.Modularity;

namespace Zion.System;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class SystemDomainTestBase<TStartupModule> : SystemTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
