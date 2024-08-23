using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Zion.System.AdContext;

public class AdAppServiceTests : SystemApplicationTestBase
{
    private readonly IAdAppService _adAppService;

    public AdAppServiceTests()
    {
        _adAppService = GetRequiredService<IAdAppService>();
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

