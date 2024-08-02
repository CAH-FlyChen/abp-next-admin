using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace Zion.System.RegionContext;

public class RegionAppServiceTests<TStartupModule> : SystemApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly IRegionAppService _regionAppService;

    public RegionAppServiceTests()
    {
        _regionAppService = GetRequiredService<IRegionAppService>();
    }

    /*
    [Fact]
    public async Task Test1()
    {
        // Arrange

        // Act

        // Assert
    }
    */
}

