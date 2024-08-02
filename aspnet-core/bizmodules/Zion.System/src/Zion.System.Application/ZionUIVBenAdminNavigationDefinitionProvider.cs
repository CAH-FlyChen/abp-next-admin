using LINGYUN.Abp.UI.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.MultiTenancy;

namespace Zion.System;
public class ZionUIVBenAdminNavigationDefinitionProvider: NavigationDefinitionProvider
{
    public override void Define(INavigationDefinitionContext context)
    {
        context.Add(GetSystem());
    }

    private static NavigationDefinition GetSystem()
    {
        var sys = new ApplicationMenu(
            name: "System",
            displayName: "系统管理",
            url: "/system",
            component: "",
            description: "系统管理",
            icon: "ant-design:cloud-server-outlined",
            multiTenancySides: MultiTenancySides.Host);
        sys.AddItem(
          new ApplicationMenu(
              name: "Company",
              displayName: "公司信息",
              url: "/system/company",
              component: "/system/company/index",
              description: "公司信息",
              multiTenancySides: MultiTenancySides.Host));
        sys.AddItem(
          new ApplicationMenu(
              name: "Region",
              displayName: "国家区域信息",
              url: "/system/region",
              component: "/system/region/index",
              description: "公司信息",
              multiTenancySides: MultiTenancySides.Host));
        return new NavigationDefinition(sys);
    }
}
