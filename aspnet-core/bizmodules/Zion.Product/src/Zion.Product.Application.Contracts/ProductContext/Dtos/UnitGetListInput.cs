using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace Zion.Product.ProductContext.Dtos;

[Serializable]
public class UnitGetListInput : PagedAndSortedResultRequestDto
{
    /// <summary>
    /// 名称
    /// </summary>
    [DisplayName("UnitName")]
    public string? Name { get; set; }
}