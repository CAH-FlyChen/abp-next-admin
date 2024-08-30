using System;
using System.Linq;
using System.Threading.Tasks;
using Zion.Product.Permissions;
using Zion.Product.ProductContext.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;
using Zion.AppService;
using Volo.Abp.Domain.Entities.Events.Distributed;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;

namespace Zion.Product.ProductContext;


public class ProductAppService : ZionCrudAppService<Product, ProductDto, Guid, ProductGetListInput, ProductCreateDto, ProductUpdateDto>,
    IProductAppService
{
    protected override string GetPolicyName { get; set; } = ProductPermissions.Product.Default;
    protected override string GetListPolicyName { get; set; } = ProductPermissions.Product.Default;
    protected override string CreatePolicyName { get; set; } = ProductPermissions.Product.Create;
    protected override string UpdatePolicyName { get; set; } = ProductPermissions.Product.Update;
    protected override string DeletePolicyName { get; set; } = ProductPermissions.Product.Delete;

    private readonly IProductRepository _repository;
    private DtoHelper dtoHelper => LazyServiceProvider.LazyGetRequiredService<DtoHelper>();

    public ProductAppService(IProductRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<IQueryable<Product>> CreateFilteredQueryAsync(ProductGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(input.Code != null, x => x.Code == input.Code)
            .WhereIf(!input.Name.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Name))
            .WhereIf(input.BrandId != null, x => x.BrandId == input.BrandId)
            .WhereIf(input.CategoryId != null, x => x.CategoryId == input.CategoryId)
            .WhereIf(input.Description != null, x => x.Description == input.Description)
            .WhereIf(input.CompanyId != null, x => x.CompanyId == input.CompanyId)
            .WhereIf(input.IsValid != null, x => x.IsValid == input.IsValid)
            .WhereIf(input.IsSuggest != null, x => x.IsSuggest == input.IsSuggest)
            ;
    }

    public override async Task<ProductDto> CreateAsync(ProductCreateDto input)
    {
        await CheckCreatePolicyAsync();

        var entity = new Product(GuidGenerator.Create(), input.Code, input.Name, input.BrandId, input.CategoryId, input.Description,input.ImageUrl,input.IsSuggest,
            input.IsValid,input.SpecTemplateJsonData,ZionContext.CurrentCompanyId!.Value);

        TryToSetTenantId(entity);

        await Repository.InsertAsync(entity, autoSave: true);

        return await MapToGetOutputDtoAsync(entity);
    }

    public override async Task<PagedResultDto<ProductDto>> GetListAsync(ProductGetListInput input)
    {
        await CheckGetListPolicyAsync();

        var query = await CreateFilteredQueryAsync(input);

        var totalCount = await AsyncExecuter.CountAsync(query);

        query = ApplySorting(query, input);
        query = ApplyPaging(query, input);

        var entities = await AsyncExecuter.ToListAsync(query);
        var entityDtos = await MapToGetListOutputDtosAsync(entities);

        await dtoHelper.FillBrandInfoDto(entityDtos);
        await dtoHelper.FillCategoryInfoDto(entityDtos);

        return new PagedResultDto<ProductDto>(
            totalCount,
            entityDtos
        );

    }

    public async Task<PagedResultDto<ProductDto>> GetNewListAsync(ProductGetListInput input)
    {
        await CheckGetListPolicyAsync();

        var query = await CreateFilteredQueryAsync(input);

        var totalCount = await AsyncExecuter.CountAsync(query);

        //query = ApplySorting(query, input);
        query = query.OrderByDescending(t=>t.CreationTime);
        query = ApplyPaging(query, input);

        var entities = await AsyncExecuter.ToListAsync(query);
        var entityDtos = await MapToGetListOutputDtosAsync(entities);

        await dtoHelper.FillBrandInfoDto(entityDtos);
        await dtoHelper.FillCategoryInfoDto(entityDtos);

        return new PagedResultDto<ProductDto>(
            totalCount,
            entityDtos
        );

    }

    public async Task<PagedResultDto<ProductDto>> GetHotListAsync(ProductGetListInput input)
    {
        await CheckGetListPolicyAsync();

        var query = await CreateFilteredQueryAsync(input);

        var totalCount = await AsyncExecuter.CountAsync(query);

        //query = ApplySorting(query, input);
        query = query.OrderByDescending(t => t.CreationTime);
        query = ApplyPaging(query, input);

        var entities = await AsyncExecuter.ToListAsync(query);
        var entityDtos = await MapToGetListOutputDtosAsync(entities);

        await dtoHelper.FillBrandInfoDto(entityDtos);
        await dtoHelper.FillCategoryInfoDto(entityDtos);

        return new PagedResultDto<ProductDto>(
            totalCount,
            entityDtos
        );

    }

    public async Task<ProductDto> GetAsync(Guid id)
    {
        await CheckGetPolicyAsync();

        var entity = (await _repository.WithDetailsAsync(t=>t.SKUs)).Single(t=>t.Id == id);

        var r = await MapToGetOutputDtoAsync(entity);

        await dtoHelper.FillBrandInfoDto(new List<ProductDto>() { r });
        await dtoHelper.FillCategoryListDto(new List<ProductDto>() { r });
        //sku


        return r;
    }
}
