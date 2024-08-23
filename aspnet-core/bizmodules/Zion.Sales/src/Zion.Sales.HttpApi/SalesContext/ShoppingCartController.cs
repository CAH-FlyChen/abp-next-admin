using System;
using Zion.Sales.SalesContext.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Zion.Sales.SalesContext;

[RemoteService(Name = SalesRemoteServiceConsts.RemoteServiceName)]
[Route("/api/sales/shopping-cart")]
public class ShoppingCartController : SalesController, IShoppingCartAppService
{
    private readonly IShoppingCartAppService _service;

    public ShoppingCartController(IShoppingCartAppService service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("")]
        public virtual Task<ShoppingCartDto> CreateAsync(ShoppingCartCreateDto input)
    {
        return _service.CreateAsync(input);
    }

    [HttpPut]
    [Route("{id}")]
        public virtual Task<ShoppingCartDto> UpdateAsync(Guid id, ShoppingCartUpdateDto input)
    {
        return _service.UpdateAsync(id, input);
    }

    [HttpDelete]
    [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
    {
        return _service.DeleteAsync(id);
    }

    [HttpGet]
    [Route("{id}")]
        public virtual Task<ShoppingCartDto> GetAsync(Guid id)
    {
        return _service.GetAsync(id);
    }

    [HttpGet]
    [Route("")]
        public virtual Task<PagedResultDto<ShoppingCartDto>> GetListAsync(ShoppingCartGetListInput input)
    {
        return _service.GetListAsync(input);
    }
}