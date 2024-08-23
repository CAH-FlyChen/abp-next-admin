using System;
using System.Threading.Tasks;
using Zion.System.AdContext;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Zion.System.EntityFrameworkCore.AdContext;

public class AdRepositoryTests : SystemEntityFrameworkCoreTestBase
{
    private readonly IAdRepository _adRepository;

    public AdRepositoryTests()
    {
        _adRepository = GetRequiredService<IAdRepository>();
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
