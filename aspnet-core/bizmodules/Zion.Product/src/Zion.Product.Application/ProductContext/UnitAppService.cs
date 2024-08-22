using System;
using System.Linq;
using System.Threading.Tasks;
using Zion.Product.Permissions;
using Zion.Product.ProductContext.Dtos;
using Volo.Abp.Application.Services;

namespace Zion.Product.ProductContext;


/// <summary>
/// 产品单位
/// </summary>
public class UnitAppService : CrudAppService<Unit, UnitDto, Guid, UnitGetListInput, UnitCreateDto, UnitUpdateDto>,
    IUnitAppService
{
    protected override string GetPolicyName { get; set; } = ProductPermissions.Unit.Default;
    protected override string GetListPolicyName { get; set; } = ProductPermissions.Unit.Default;
    protected override string CreatePolicyName { get; set; } = ProductPermissions.Unit.Create;
    protected override string UpdatePolicyName { get; set; } = ProductPermissions.Unit.Update;
    protected override string DeletePolicyName { get; set; } = ProductPermissions.Unit.Delete;

    private readonly IUnitRepository _repository;

    public UnitAppService(IUnitRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<IQueryable<Unit>> CreateFilteredQueryAsync(UnitGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(!input.Name.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Name))
            ;
    }
}
