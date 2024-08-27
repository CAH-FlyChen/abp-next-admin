using System;
using System.Linq;
using System.Threading.Tasks;
using Zion.Product.Permissions;
using Zion.Product.Dtos;
using Volo.Abp.Application.Services;
using System.Collections.Generic;
using Zion.System.RegionContext;
using Zion.Product.ProductContext.Dtos;
using Volo.Abp.Application.Dtos;

namespace Zion.Product.ProductContext;


public class CategoryAppService : CrudAppService<Category, CategoryDto, Guid, CategoryGetListInput, CategoryCreateDto, CategoryUpdateDto>,
    ICategoryAppService
{
    protected override string GetPolicyName { get; set; } = ProductPermissions.Category.Default;
    protected override string GetListPolicyName { get; set; } = ProductPermissions.Category.Default;
    protected override string CreatePolicyName { get; set; } = ProductPermissions.Category.Create;
    protected override string UpdatePolicyName { get; set; } = ProductPermissions.Category.Update;
    protected override string DeletePolicyName { get; set; } = ProductPermissions.Category.Delete;

    private readonly ICategoryRepository _repository;
    private IProductRepository _productRepository => LazyServiceProvider.LazyGetRequiredService<IProductRepository>();
    private DtoHelper _dtoHelper => LazyServiceProvider.LazyGetRequiredService<DtoHelper>();

    public CategoryAppService(ICategoryRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<IQueryable<Category>> CreateFilteredQueryAsync(CategoryGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(!input.Name.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Name))
            .WhereIf(input.Level != null, x => x.Level == input.Level)
            .WhereIf(input.ParentId != null, x => x.ParentId == input.ParentId)
            .WhereIf(input.Children != null, x => x.Children == input.Children)
            .WhereIf(input.DUId != null, x => x.DUId == input.DUId)
            ;
    }

    public async Task<PagedResultDto<CategoryDto>> GetRootListAsync(CategoryGetListInput input)
    {
        //await CheckGetListPolicyAsync();


        var query = await CreateFilteredQueryAsync(input);
        query.Where(t => t.ParentId == null);

        var totalCount = await AsyncExecuter.CountAsync(query);


        query = ApplySorting(query, input);
        query = ApplyPaging(query, input);


        var entities = await AsyncExecuter.ToListAsync(query);
        var entityDtos = await MapToGetListOutputDtosAsync(entities);


        return new PagedResultDto<CategoryDto>(
            totalCount,
            entityDtos
        );
    }

    public override async Task<PagedResultDto<CategoryDto>> GetListAsync(CategoryGetListInput input)
    {
        //await CheckGetListPolicyAsync();


        var query = await CreateFilteredQueryAsync(input);


        var totalCount = await AsyncExecuter.CountAsync(query);


        query = ApplySorting(query, input);
        query = ApplyPaging(query, input);


        var entities = await AsyncExecuter.ToListAsync(query);
        var entityDtos = await MapToGetListOutputDtosAsync(entities);


        return new PagedResultDto<CategoryDto>(
            totalCount,
            entityDtos
        );
    }

    /// <summary>
    /// 获取树状数据
    /// </summary>
    /// <returns></returns>
    public async Task<List<GetCategoryTreeResultItemDto>> GetTreeData(Guid? id,bool isResultIncludeProduct=false)
    {
        var data = await _repository.GetListAsync();

        var r = new List<GetCategoryTreeResultItemDto>();
        //没有指定Id
        if (id == null) {
            r = BuildTreeItems(data, null);
        }
        else
        {
            //指定了id
            var rootItem = data.SingleOrDefault(t => t.Id == id);
            var rootItemDto = new GetCategoryTreeResultItemDto()
            {
                Id = rootItem.Id,
                Name = rootItem.Name,
                ParentId = rootItem.ParentId,
                ImageUrl = rootItem.ImageUrl
            };

            rootItemDto.Children = BuildTreeItems(data, id);
            r.Add(rootItemDto);
        }

        if(isResultIncludeProduct)
            await _dtoHelper.FillProductDto(r);

        return r;
    }







    /// <summary>
    /// 构建树装结构
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private List<GetCategoryTreeResultItemDto> BuildTreeItems(List<Category> data, Guid? parentId)
    {
        var items = data.Where(t => t.ParentId == parentId).Select(t => new GetCategoryTreeResultItemDto()
        {
            Name = t.Name,
            Id = t.Id,
            ParentId = t.ParentId,
            ImageUrl = t.ImageUrl,
        }).ToList();

        foreach(var  item in items)
        {
            item.Children = BuildTreeItems(data, item.Id);
        }

        return items;
    }
}
