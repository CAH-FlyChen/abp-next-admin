using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Zion.Product.PriceContext;

public class PriceAppServiceTests : ProductApplicationTestBase
{
    private readonly IPriceAppService _priceAppService;

    public PriceAppServiceTests()
    {
        _priceAppService = GetRequiredService<IPriceAppService>();
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

