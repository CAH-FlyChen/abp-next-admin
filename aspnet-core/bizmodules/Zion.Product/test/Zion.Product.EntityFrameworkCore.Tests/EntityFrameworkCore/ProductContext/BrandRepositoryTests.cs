using System;
using System.Threading.Tasks;
using Zion.Product.ProductContext;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Zion.Product.EntityFrameworkCore.ProductContext;

public class BrandRepositoryTests : ProductEntityFrameworkCoreTestBase
{
    private readonly IBrandRepository _brandRepository;

    public BrandRepositoryTests()
    {
        _brandRepository = GetRequiredService<IBrandRepository>();
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
