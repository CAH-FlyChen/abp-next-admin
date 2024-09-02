using System;
using System.Threading.Tasks;
using Zion.Product.PriceContext;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Zion.Product.EntityFrameworkCore.PriceContext;

public class PriceRepositoryTests : ProductEntityFrameworkCoreTestBase
{
    private readonly IPriceRepository _priceRepository;

    public PriceRepositoryTests()
    {
        _priceRepository = GetRequiredService<IPriceRepository>();
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
