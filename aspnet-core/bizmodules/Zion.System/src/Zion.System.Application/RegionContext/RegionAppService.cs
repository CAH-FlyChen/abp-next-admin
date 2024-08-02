using System;
using System.Linq;
using System.Threading.Tasks;
using Zion.System.Permissions;
using Zion.System.RegionContext.Dtos;
using Volo.Abp.Application.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace Zion.System.RegionContext;


/// <summary>
/// 行政区域
/// </summary>
public class RegionAppService : AbstractKeyCrudAppService<Region, RegionDto, RegionKey, RegionGetListInput, RegionCreateDto, RegionUpdateDto>,
    IRegionAppService
{
    protected override string GetPolicyName { get; set; } = SystemPermissions.Region.Default;
    protected override string GetListPolicyName { get; set; } = SystemPermissions.Region.Default;
    protected override string CreatePolicyName { get; set; } = SystemPermissions.Region.Create;
    protected override string UpdatePolicyName { get; set; } = SystemPermissions.Region.Update;
    protected override string DeletePolicyName { get; set; } = SystemPermissions.Region.Delete;

    private readonly IRegionRepository _repository;

    public RegionAppService(IRegionRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override Task DeleteByIdAsync(RegionKey id)
    {
        // TODO: AbpHelper generated
        return _repository.DeleteAsync(e =>
            e.Code == id.Code
        );
    }

    protected override async Task<Region> GetEntityByIdAsync(RegionKey id)
    {
        // TODO: AbpHelper generated
        return await AsyncExecuter.FirstOrDefaultAsync(
            (await _repository.WithDetailsAsync()).Where(e =>
                e.Code == id.Code
            ));
    }

    protected override IQueryable<Region> ApplyDefaultSorting(IQueryable<Region> query)
    {
        // TODO: AbpHelper generated
        return query.OrderBy(e => e.Code);
    }

    protected override async Task<IQueryable<Region>> CreateFilteredQueryAsync(RegionGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(!input.Code.IsNullOrWhiteSpace(), x => x.Code.Contains(input.Code))
            .WhereIf(!input.Name.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Name))
            .WhereIf(!input.ParentCode.IsNullOrWhiteSpace(), x => x.ParentCode.Contains(input.ParentCode))
            .WhereIf(input.RegionTypeCode != null, x => x.RegionTypeCode == input.RegionTypeCode)
            ;
    }

    public class GetTreeResultItemDto
    {
        /// <summary>
        /// 行政区域代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 上级Code
        /// </summary>
        public string? ParentCode { get; set; }

        /// <summary>
        /// 类型 区域类型，国家 0，省 1，市 2，区县 3
        /// </summary>
        public RegionType RegionTypeCode { get; set; }

        public List<GetTreeResultItemDto> Children { get; set; }
    }
    /// <summary>
    /// 获取树状数据
    /// </summary>
    /// <returns></returns>
    public async Task<List<GetTreeResultItemDto>> GetTree()
    {
        var r = new List<GetTreeResultItemDto>();

        var data = await _repository.GetListAsync();
        var province = data.Where(t=>t.RegionTypeCode == RegionType.省);
        foreach(var p in province)
        {
            var pitem = new GetTreeResultItemDto()
            {
                Code = p.Code,
                Name = p.Name,
                RegionTypeCode = p.RegionTypeCode,
                ParentCode = p.ParentCode,
                Children = new List<GetTreeResultItemDto>()
            };
            r.Add(pitem);
            var citys = data.Where(t => t.ParentCode == p.Code && t.RegionTypeCode == RegionType.市);
            foreach( var city in citys)
            {
                var citem = new GetTreeResultItemDto()
                {
                    Code = city.Code,
                    Name = city.Name,
                    RegionTypeCode = city.RegionTypeCode,
                    ParentCode = city.ParentCode,
                    Children = new List<GetTreeResultItemDto>()
                };
                pitem.Children.Add(citem);
                var disticts = data.Where(t => t.ParentCode == city.Code && t.RegionTypeCode == RegionType.区县);
                foreach(var d in disticts)
                {
                    var ditem = new GetTreeResultItemDto()
                    {
                        Code = d.Code,
                        Name = d.Name,
                        RegionTypeCode = d.RegionTypeCode,
                        ParentCode = d.ParentCode
                    };
                    citem.Children.Add(ditem);
                }
            }
        }
        return r;
    }
}
