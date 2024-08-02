using Zion.System.RegionContext;
using Zion.System.CompanyContext;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Zion.System.EntityFrameworkCore;

[DependsOn(
    typeof(SystemDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class SystemEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<SystemDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
            options.AddRepository<Company, CompanyRepository>();
            options.AddRepository<Region, RegionRepository>();
        });
    }
}
