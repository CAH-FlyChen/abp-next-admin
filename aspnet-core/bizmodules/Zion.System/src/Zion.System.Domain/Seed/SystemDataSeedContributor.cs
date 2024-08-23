using LINGYUN.Platform.Datas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Zion.System.RegionContext;

namespace Zion.System;
public class SystemDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    public IAbpLazyServiceProvider LazyServiceProvider { get; set; } = default!;

    private IRegionRepository _regionRepository => LazyServiceProvider.LazyGetRequiredService<IRegionRepository>();
    private IDataDictionaryDataSeeder _dataDictSeeder => LazyServiceProvider.LazyGetRequiredService<IDataDictionaryDataSeeder>();
    private IGuidGenerator _guidGenerator => LazyServiceProvider.LazyGetRequiredService<IGuidGenerator>();

    public async Task SeedAsync(DataSeedContext context)
    {
        await SeedRegion();
        await SeedAdType();
    }

    private async Task SeedAdType()
    {
        var data = await _dataDictSeeder
            .SeedAsync(
                "AdType",
                "AdType",
                "广告类型",
                "用于广告模块中的广告分类",
                null,
                null,
                true);

        data.AddItem(_guidGenerator, "Barnner", "首页Barnner", "Barnner", isStatic: true);

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
