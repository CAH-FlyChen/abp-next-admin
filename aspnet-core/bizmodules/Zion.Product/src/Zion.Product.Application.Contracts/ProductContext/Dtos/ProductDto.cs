using System;
using Volo.Abp.Application.Dtos;

namespace Zion.Product.ProductContext.Dtos;

[Serializable]
public class ProductDto : FullAuditedEntityDto<Guid>
{
    /// <summary>
    /// 自有唯一编码
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// 产品名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 产品品牌Id
    /// </summary>
    public Guid? BrandId { get; set; }

    /// <summary>
    /// 产品分类Id
    /// </summary>
    public Guid? CategoryId { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// 是否推荐
    /// </summary>
    public bool IsSuggest { get; set; }

    /// <summary>
    /// 公司Id
    /// </summary>
    public Guid CompanyId { get; set; }

    public bool IsValid { get; set; }

    public BrandSimpleDto? Brand { get; set; }
    public CategorySimpleDto? Category { get; set; }
}