using System;
using System.Threading.Tasks;
using Zion.Product;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Zion.Product.EntityFrameworkCore.Zion.Product;

public class CategoryRepositoryTests : ProductEntityFrameworkCoreTestBase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryRepositoryTests()
    {
        _categoryRepository = GetRequiredService<ICategoryRepository>();
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
