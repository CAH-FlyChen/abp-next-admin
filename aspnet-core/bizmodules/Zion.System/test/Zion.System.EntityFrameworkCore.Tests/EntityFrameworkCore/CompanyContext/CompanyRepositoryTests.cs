using System;
using System.Threading.Tasks;
using Zion.System.CompanyContext;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Zion.System.EntityFrameworkCore.CompanyContext;

public class CompanyRepositoryTests : SystemEntityFrameworkCoreTestBase
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyRepositoryTests()
    {
        _companyRepository = GetRequiredService<ICompanyRepository>();
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
