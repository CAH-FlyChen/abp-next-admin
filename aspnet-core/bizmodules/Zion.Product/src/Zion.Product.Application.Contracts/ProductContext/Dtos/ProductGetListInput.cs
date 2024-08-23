using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace Zion.Product.ProductContext.Dtos;

[Serializable]
public class ProductGetListInput : PagedAndSortedResultRequestDto
{
    /// <summary>
    /// 自有唯一编码
    /// </summary>
    [DisplayName("ProductCode")]
    public string? Code { get; set; }

    /// <summary>
    /// 产品名称
    /// </summary>
    [DisplayName("ProductName")]
    public string? Name { get; set; }

    /// <summary>
    /// 产品品牌Id
    /// </summary>
    [DisplayName("ProductBrandId")]
    public Guid? BrandId { get; set; }

    /// <summary>
    /// 产品分类Id
    /// </summary>
    [DisplayName("ProductCategoryId")]
    public Guid? CategoryId { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    [DisplayName("ProductDescription")]
    public string? Description { get; set; }
    /// <summary>
    /// 是否为推荐商品
    /// </summary>
    public bool? IsSuggest { get; set; }
    /// <summary>
    /// 公司Id
    /// </summary>
    [DisplayName("ProductCompanyId")]
    public Guid? CompanyId { get; set; }

    [DisplayName("ProductIsValid")]
    public bool? IsValid { get; set; }

}