using System;
using System.Linq;
using System.Threading.Tasks;
using Zion.Product.Permissions;
using Zion.Product.ProductContext.Dtos;
using Volo.Abp.Application.Services;

namespace Zion.Product.ProductContext;


/// <summary>
/// 产品品牌
/// </summary>
public class BrandAppService : CrudAppService<Brand, BrandDto, Guid, BrandGetListInput, BrandCreateDto, BrandUpdateDto>,
    IBrandAppService
{
    protected override string GetPolicyName { get; set; } = ProductPermissions.Brand.Default;
    protected override string GetListPolicyName { get; set; } = ProductPermissions.Brand.Default;
    protected override string CreatePolicyName { get; set; } = ProductPermissions.Brand.Create;
    protected override string UpdatePolicyName { get; set; } = ProductPermissions.Brand.Update;
    protected override string DeletePolicyName { get; set; } = ProductPermissions.Brand.Delete;

    private readonly IBrandRepository _repository;

    public BrandAppService(IBrandRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<IQueryable<Brand>> CreateFilteredQueryAsync(BrandGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(!input.Name.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Name))
            .WhereIf(!input.JP.IsNullOrWhiteSpace(), x => x.JP.Contains(input.JP))
            .WhereIf(!input.InitialChar.IsNullOrWhiteSpace(), x => x.InitialChar.Contains(input.InitialChar))
            ;
    }

    public override async Task<BrandDto> CreateAsync(BrandCreateDto input)
    {
        await CheckCreatePolicyAsync();


        var entity = new Brand(GuidGenerator.Create(),input.Name,input.ImgUrl);


        TryToSetTenantId(entity);


        await Repository.InsertAsync(entity, autoSave: true);


        return await MapToGetOutputDtoAsync(entity);
    }

    public override async Task<BrandDto> UpdateAsync(Guid id, BrandUpdateDto input)
    {
        await CheckUpdatePolicyAsync();


        var entity = await GetEntityByIdAsync(id);
        //TODO: Check if input has id different than given id and normalize if it's default value, throw ex otherwise
        entity.Update(input.Name, input.JP, input.InitialChar, input.ImgUrl);
        await Repository.UpdateAsync(entity, autoSave: true);


        return await MapToGetOutputDtoAsync(entity);
    }
}
