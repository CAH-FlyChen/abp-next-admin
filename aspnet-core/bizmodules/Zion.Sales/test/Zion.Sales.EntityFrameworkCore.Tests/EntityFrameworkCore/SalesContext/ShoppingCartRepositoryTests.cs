using System;
using System.Threading.Tasks;
using Zion.Sales.SalesContext;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Zion.Sales.EntityFrameworkCore.SalesContext;

public class ShoppingCartRepositoryTests : SalesEntityFrameworkCoreTestBase
{
    private readonly IShoppingCartRepository _shoppingCartRepository;

    public ShoppingCartRepositoryTests()
    {
        _shoppingCartRepository = GetRequiredService<IShoppingCartRepository>();
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
