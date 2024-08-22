using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Zion.Product.ProductContext;

public class UnitAppServiceTests : ProductApplicationTestBase
{
    private readonly IUnitAppService _unitAppService;

    public UnitAppServiceTests()
    {
        _unitAppService = GetRequiredService<IUnitAppService>();
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

