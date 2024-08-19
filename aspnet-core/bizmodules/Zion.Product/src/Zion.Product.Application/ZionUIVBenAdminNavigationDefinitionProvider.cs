using LINGYUN.Abp.UI.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.MultiTenancy;

namespace Zion.Product;
public class ZionUIVBenAdminNavigationDefinitionProvider: NavigationDefinitionProvider
{
    public override void Define(INavigationDefinitionContext context)
    {
        context.Add(GetSystem());
    }

    private static NavigationDefinition GetSystem()
    {
        var root = new ApplicationMenu(
            name: "Product",
            displayName: "产品管理",
            url: "/product",
            component: "",
            description: "产品管理",
            icon: "ant-design:cloud-server-outlined",
            multiTenancySides: MultiTenancySides.Host);

        root.AddItem(
          new ApplicationMenu(
              name: "Category",
              displayName: "产品分类",
              url: "/system/category",
              component: "/system/company/category",
              description: "产品分类信息",
              multiTenancySides: MultiTenancySides.Host));

        return new NavigationDefinition(root);
    }
}
