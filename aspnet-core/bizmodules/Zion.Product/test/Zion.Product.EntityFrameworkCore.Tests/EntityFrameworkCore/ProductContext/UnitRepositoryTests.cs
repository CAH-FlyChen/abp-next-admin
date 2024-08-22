using System;
using System.Threading.Tasks;
using Zion.Product.ProductContext;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Zion.Product.EntityFrameworkCore.ProductContext;

public class UnitRepositoryTests : ProductEntityFrameworkCoreTestBase
{
    private readonly IUnitRepository _unitRepository;

    public UnitRepositoryTests()
    {
        _unitRepository = GetRequiredService<IUnitRepository>();
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
