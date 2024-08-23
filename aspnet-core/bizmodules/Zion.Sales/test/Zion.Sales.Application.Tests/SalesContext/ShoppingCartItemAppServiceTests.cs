using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Zion.Sales.SalesContext;

public class ShoppingCartItemAppServiceTests : SalesApplicationTestBase
{
    private readonly IShoppingCartItemAppService _shoppingCartItemAppService;

    public ShoppingCartItemAppServiceTests()
    {
        _shoppingCartItemAppService = GetRequiredService<IShoppingCartItemAppService>();
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

