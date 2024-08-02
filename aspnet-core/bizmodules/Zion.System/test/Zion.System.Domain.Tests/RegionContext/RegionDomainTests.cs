using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Modularity;
using Xunit;

namespace Zion.System.RegionContext;

public class RegionDomainTests<TStartupModule> : SystemDomainTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    public RegionDomainTests()
    {
    }

    /*
    [Fact]
    public async Task Test1()
    {
        // Arrange

        // Assert

        // Assert
    }
    */
}