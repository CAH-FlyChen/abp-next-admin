using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace Zion.System.CompanyContext;

public class CompanyAppServiceTests<TStartupModule> : SystemApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly ICompanyAppService _companyAppService;

    public CompanyAppServiceTests()
    {
        _companyAppService = GetRequiredService<ICompanyAppService>();
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

