using System;
using System.Threading.Tasks;
using Zion.System.RegionContext;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Zion.System.EntityFrameworkCore.RegionContext;

public class RegionRepositoryTests : SystemEntityFrameworkCoreTestBase
{
    private readonly IRegionRepository _regionRepository;

    public RegionRepositoryTests()
    {
        _regionRepository = GetRequiredService<IRegionRepository>();
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
