using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Modularity;
using Xunit;

namespace Zion.System.CompanyContext;

public class CompanyDomainTests<TStartupModule> : SystemDomainTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    public CompanyDomainTests()
    {
    }

    /*
    [Fact]
    public async Task Test1()
    {
        // Arrange

        // Assert

        // Assert
    }
    */
}