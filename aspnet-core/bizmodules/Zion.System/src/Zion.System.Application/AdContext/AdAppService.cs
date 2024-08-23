using System;
using System.Linq;
using System.Threading.Tasks;
using Zion.System.Permissions;
using Zion.System.AdContext.Dtos;
using Volo.Abp.Application.Services;

namespace Zion.System.AdContext;


/// <summary>
/// 广告
/// </summary>
public class AdAppService : CrudAppService<Ad, AdDto, Guid, AdGetListInput, AdCreateDto, AdUpdateDto>,
    IAdAppService
{
    protected override string GetPolicyName { get; set; } = SystemPermissions.Ad.Default;
    protected override string GetListPolicyName { get; set; } = SystemPermissions.Ad.Default;
    protected override string CreatePolicyName { get; set; } = SystemPermissions.Ad.Create;
    protected override string UpdatePolicyName { get; set; } = SystemPermissions.Ad.Update;
    protected override string DeletePolicyName { get; set; } = SystemPermissions.Ad.Delete;

    private readonly IAdRepository _repository;

    public AdAppService(IAdRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<IQueryable<Ad>> CreateFilteredQueryAsync(AdGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(!input.Name.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Name))
            .WhereIf(!input.ImageUrl.IsNullOrWhiteSpace(), x => x.ImageUrl.Contains(input.ImageUrl))
            .WhereIf(input.SortOrder != null, x => x.SortOrder == input.SortOrder)
            .WhereIf(input.TypeCode != null, x => x.TypeCode == input.TypeCode)
            .WhereIf(!input.TargetUrl.IsNullOrWhiteSpace(), x => x.TargetUrl.Contains(input.TargetUrl))
            .WhereIf(input.ExpDateTime != null, x => x.ExpDateTime == input.ExpDateTime)
            .WhereIf(!input.Description.IsNullOrWhiteSpace(), x => x.Description.Contains(input.Description))
            ;
    }
}
