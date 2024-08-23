using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Zion.Sales.SalesContext;

public class ShoppingCartAppServiceTests : SalesApplicationTestBase
{
    private readonly IShoppingCartAppService _shoppingCartAppService;

    public ShoppingCartAppServiceTests()
    {
        _shoppingCartAppService = GetRequiredService<IShoppingCartAppService>();
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

