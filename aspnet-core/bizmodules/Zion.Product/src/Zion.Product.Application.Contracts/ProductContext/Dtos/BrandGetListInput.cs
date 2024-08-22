using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace Zion.Product.ProductContext.Dtos;

[Serializable]
public class BrandGetListInput : PagedAndSortedResultRequestDto
{
    /// <summary>
    /// 品牌名称
    /// </summary>
    [DisplayName("BrandName")]
    public string? Name { get; set; }

    /// <summary>
    /// 简拼
    /// </summary>
    [DisplayName("BrandJP")]
    public string? JP { get; set; }

    /// <summary>
    /// 首字母
    /// </summary>
    [DisplayName("BrandInitialChar")]
    public string? InitialChar { get; set; }
}