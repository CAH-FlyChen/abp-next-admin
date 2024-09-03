using System;
using System.Linq;
using System.Threading.Tasks;
using Zion.Product.Permissions;
using Zion.Product.PriceContext.Dtos;
using Volo.Abp.Application.Services;
using Zion.Product.ProductContext;
using Volo.Abp.Domain.Entities;
using System.Collections.Generic;
using System.Net.Http.Headers;

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
    IProductRepository _productRepository => LazyServiceProvider.LazyGetRequiredService<IProductRepository>();

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

    /// <summary>
    /// 后端端根据商品id获取价格列表
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    //public async Task<List<PriceDto>> GetByProductIdAsync(Guid productId)
    //{
    //    await CheckGetPolicyAsync();

    //    var entitys = await _repository.GetListAsync(x => x.ProductId == productId);

    //    var skus = (await _productRepository.WithDetailsAsync(t => t.SKUs)).Single(t => t.Id == productId).SKUs;

    //    var dtos = entitys.Select(t => ObjectMapper.Map<Price,PriceDto>(t));
    //    foreach(var dto in dtos)
    //    {
    //        var sku = skus.SingleOrDefault(t => t.Id == dto.ProductSKUId);
    //        if (sku == null) continue;
    //        dto.SKU = ObjectMapper.Map<ProductSku,ProductSkuDto>(sku);
    //    }

    //    return dtos.ToList();
    //}
}
