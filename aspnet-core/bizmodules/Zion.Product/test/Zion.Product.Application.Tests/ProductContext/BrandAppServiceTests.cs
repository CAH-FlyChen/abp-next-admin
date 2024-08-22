using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Zion.Product.ProductContext;

public class BrandAppServiceTests : ProductApplicationTestBase
{
    private readonly IBrandAppService _brandAppService;

    public BrandAppServiceTests()
    {
        _brandAppService = GetRequiredService<IBrandAppService>();
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

