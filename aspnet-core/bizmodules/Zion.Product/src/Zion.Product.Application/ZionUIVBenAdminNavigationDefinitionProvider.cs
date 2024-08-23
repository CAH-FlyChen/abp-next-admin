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
            name: "ProductGroup",
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
              url: "/product/category",
              component: "/product/category/index",
              description: "产品分类信息",
              multiTenancySides: MultiTenancySides.Host));

        root.AddItem(
          new ApplicationMenu(
              name: "Brand",
              displayName: "产品品牌",
              url: "/product/brand",
              component: "/product/brand/index",
              description: "产品品牌信息",
              multiTenancySides: MultiTenancySides.Host));

        root.AddItem(
          new ApplicationMenu(
              name: "Unit",
              displayName: "产品单位",
              url: "/product/unit",
              component: "/product/unit/index",
              description: "产品单位信息",
              multiTenancySides: MultiTenancySides.Host));

        root.AddItem(
          new ApplicationMenu(
              name: "Product",
              displayName: "产品信息",
              url: "/product/product",
              component: "/product/product/index",
              description: "产品信息",
              multiTenancySides: MultiTenancySides.Host));

        return new NavigationDefinition(root);
    }
}
