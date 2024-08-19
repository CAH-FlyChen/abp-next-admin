using LINGYUN.Abp.UI.Navigation.VueVbenAdmin;
using LY.MicroService.Applications.Single.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Zion.Product;
using Zion.Product.EntityFrameworkCore;
using Zion.System;
using Zion.System.EntityFrameworkCore;

namespace LY.MicroService.Applications.Single.DbMigrator;

[DependsOn(
    typeof(ProductApplicationModule),//menu
    typeof(ProductEntityFrameworkCoreModule),
    typeof(SystemEntityFrameworkCoreModule),
    typeof(AbpUINavigationVueVbenAdminModule),
    typeof(SingleMigrationsEntityFrameworkCoreModule),
    typeof(AbpAutofacModule)
    )]
public partial class SingleDbMigratorModule : AbpModule
{

}
