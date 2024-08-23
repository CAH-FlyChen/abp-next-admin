using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Zion.Product.ProductContext;

public class ProductAppServiceTests : ProductApplicationTestBase
{
    private readonly IProductAppService _productAppService;

    public ProductAppServiceTests()
    {
        _productAppService = GetRequiredService<IProductAppService>();
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

