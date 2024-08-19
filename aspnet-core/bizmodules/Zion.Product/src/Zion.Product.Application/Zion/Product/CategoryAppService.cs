using System;
using System.Linq;
using System.Threading.Tasks;
using Zion.Product.Permissions;
using Zion.Product.Dtos;
using Volo.Abp.Application.Services;

namespace Zion.Product;


public class CategoryAppService : CrudAppService<Category, CategoryDto, Guid, CategoryGetListInput, CategoryCreateDto, CategoryUpdateDto>,
    ICategoryAppService
{
    protected override string GetPolicyName { get; set; } = ProductPermissions.Category.Default;
    protected override string GetListPolicyName { get; set; } = ProductPermissions.Category.Default;
    protected override string CreatePolicyName { get; set; } = ProductPermissions.Category.Create;
    protected override string UpdatePolicyName { get; set; } = ProductPermissions.Category.Update;
    protected override string DeletePolicyName { get; set; } = ProductPermissions.Category.Delete;

    private readonly ICategoryRepository _repository;

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
}
