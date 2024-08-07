using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Zion.System.RegionContext;

namespace Zion.System;
public class SystemDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    public IAbpLazyServiceProvider LazyServiceProvider { get; set; } = default!;

    private IRegionRepository _regionRepository => LazyServiceProvider.LazyGetRequiredService<IRegionRepository>();

    public async Task SeedAsync(DataSeedContext context)
    {
        await SeedRegion();
    }

    private async Task SeedRegion()
    {
        //"Code","Name","ParentCode","ReginTypeCode"
        var existCache = await _regionRepository.GetListAsync();
        using (var sr = new StreamReader(Path.Combine("Seed", "SysRegion.csv")))
        {
            while (!sr.EndOfStream)
            {
                var item = await sr.ReadLineAsync();
                if (item == null) continue;
                var s = item.Split(',');
                if (s.Length > 0)
                {
                    var r = existCache.Find(t => t.Code == s[0]);
                    if (r == null)
                    {
                        await _regionRepository.InsertAsync(new Region(s[0], s[1], s[2], GetEnumByValue(typeof(RegionType), s[3])));
                    }
                }
            }
        }
    }


    public static RegionType GetEnumByValue(Type enumType, string value)
    {
        var c = Enum.Parse(enumType, value);
        return (RegionType)c;

    }
}
