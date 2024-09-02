using System;
using System.Linq;
using System.Threading.Tasks;
using Zion.Product.Permissions;
using Zion.Product.PriceContext.Dtos;
using Volo.Abp.Application.Services;

namespace Zion.Product.PriceContext;


public class PriceAppService : CrudAppService<Price, PriceDto, Guid, PriceGetListInput, PriceCreateDto, PriceUpdateDto>,
    IPriceAppService
{
    protected override string GetPolicyName { get; set; } = ProductPermissions.Price.Default;
    protected override string GetListPolicyName { get; set; } = ProductPermissions.Price.Default;
    protected override string CreatePolicyName { get; set; } = ProductPermissions.Price.Create;
    protected override string UpdatePolicyName { get; set; } = ProductPermissions.Price.Update;
    protected override string DeletePolicyName { get; set; } = ProductPermissions.Price.Delete;

    private readonly IPriceRepository _repository;

    public PriceAppService(IPriceRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<IQueryable<Price>> CreateFilteredQueryAsync(PriceGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(input.ProductId != null, x => x.ProductId == input.ProductId)
            .WhereIf(input.PriceRetail != null, x => x.PriceRetail == input.PriceRetail)
            .WhereIf(input.PriceCombi != null, x => x.PriceCombi == input.PriceCombi)
            .WhereIf(input.PriceCost != null, x => x.PriceCost == input.PriceCost)
            .WhereIf(input.Price1 != null, x => x.Price1 == input.Price1)
            .WhereIf(input.Price2 != null, x => x.Price2 == input.Price2)
            .WhereIf(input.CompanyId != null, x => x.CompanyId == input.CompanyId)
            ;
    }

    public override async Task<PriceDto> CreateAsync(PriceCreateDto input)
    {
        await CheckCreatePolicyAsync();


        var entity = await MapToEntityAsync(input);

        TryToSetTenantId(entity);


        await Repository.InsertAsync(entity, autoSave: true);


        return await MapToGetOutputDtoAsync(entity);
    }
}
