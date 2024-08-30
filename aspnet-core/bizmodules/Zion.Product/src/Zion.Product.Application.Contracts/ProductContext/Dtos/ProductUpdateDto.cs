using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Zion.Product.ProductContext.Dtos;

[Serializable]
public class ProductUpdateDto
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
    public string Name { get; set; }

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
    /// 产品主图
    /// </summary>
    public string? ImageUrl { get; set; }
    /// <summary>
    /// 是否推荐
    /// </summary>
    public bool IsSuggest { get; set; }

    [DisplayName("ProductIsValid")]
    public bool IsValid { get; set; }

    [DisplayName("ProductDUId")]
    public Guid DUId { get; set; }

    /// <summary>
    /// 私有规格模板
    /// </summary>
    public string? SpecTemplateJsonData { get; set; }

    public List<ProductSkuDto>? SKUs { get; set; }

}