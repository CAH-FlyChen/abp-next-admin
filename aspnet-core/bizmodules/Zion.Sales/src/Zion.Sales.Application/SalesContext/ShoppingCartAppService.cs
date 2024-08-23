using System;
using System.Linq;
using System.Threading.Tasks;
using Zion.Sales.Permissions;
using Zion.Sales.SalesContext.Dtos;
using Volo.Abp.Application.Services;

namespace Zion.Sales.SalesContext;


public class ShoppingCartAppService : CrudAppService<ShoppingCart, ShoppingCartDto, Guid, ShoppingCartGetListInput, ShoppingCartCreateDto, ShoppingCartUpdateDto>,
    IShoppingCartAppService
{
    protected override string GetPolicyName { get; set; } = SalesPermissions.ShoppingCart.Default;
    protected override string GetListPolicyName { get; set; } = SalesPermissions.ShoppingCart.Default;
    protected override string CreatePolicyName { get; set; } = SalesPermissions.ShoppingCart.Create;
    protected override string UpdatePolicyName { get; set; } = SalesPermissions.ShoppingCart.Update;
    protected override string DeletePolicyName { get; set; } = SalesPermissions.ShoppingCart.Delete;

    private readonly IShoppingCartRepository _repository;

    public ShoppingCartAppService(IShoppingCartRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<IQueryable<ShoppingCart>> CreateFilteredQueryAsync(ShoppingCartGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(input.CustomerId != null, x => x.CustomerId == input.CustomerId)
            ;
    }
}
