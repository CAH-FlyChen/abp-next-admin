using System;
using System.Threading.Tasks;
using Zion.Sales.SalesContext;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Zion.Sales.EntityFrameworkCore.SalesContext;

public class ShoppingCartItemRepositoryTests : SalesEntityFrameworkCoreTestBase
{
    private readonly IShoppingCartItemRepository _shoppingCartItemRepository;

    public ShoppingCartItemRepositoryTests()
    {
        _shoppingCartItemRepository = GetRequiredService<IShoppingCartItemRepository>();
    }

    /*
    [Fact]
    public async Task Test1()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            // Arrange

            // Act

            //Assert
        });
    }
    */
}
