using Volo.Abp.Bundling;

namespace Zion.System.Blazor.Host.Client;

public class SystemBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
