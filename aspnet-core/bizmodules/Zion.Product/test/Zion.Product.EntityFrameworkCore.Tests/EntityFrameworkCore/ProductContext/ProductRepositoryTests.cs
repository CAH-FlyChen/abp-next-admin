using System;
using System.Threading.Tasks;
using Zion.Product.ProductContext;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Zion.Product.EntityFrameworkCore.ProductContext;

public class ProductRepositoryTests : ProductEntityFrameworkCoreTestBase
{
    private readonly IProductRepository _productRepository;

    public ProductRepositoryTests()
    {
        _productRepository = GetRequiredService<IProductRepository>();
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
