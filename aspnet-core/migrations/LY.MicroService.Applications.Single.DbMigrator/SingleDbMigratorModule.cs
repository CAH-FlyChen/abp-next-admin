using LINGYUN.Abp.UI.Navigation.VueVbenAdmin;
using LY.MicroService.Applications.Single.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Zion.System;

namespace LY.MicroService.Applications.Single.DbMigrator;

[DependsOn(
    typeof(SystemApplicationModule),
    typeof(AbpUINavigationVueVbenAdminModule),
    typeof(SingleMigrationsEntityFrameworkCoreModule),
    typeof(AbpAutofacModule)
    )]
public partial class SingleDbMigratorModule : AbpModule
{

}
