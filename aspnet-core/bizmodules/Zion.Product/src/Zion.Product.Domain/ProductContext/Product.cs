using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Zion.System;

namespace Zion.Product.ProductContext;
public class Product : FullAuditedAggregateRoot<Guid>,IHasCompanyIdFilter, IHasDeleteUniqueId, IHasCompanyUniqueCode, IHasIsValid
{
    /// <summary>
    /// 自有唯一编码
    /// </summary>
    [MaxLength(100)]
    public string? Code { get; set; }
    /// <summary>
    /// 产品名称
    /// </summary>
    [Required]
    [MaxLength(100)]
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
    [MaxLength(2000)]
    public string? Description { get; set; }
    /// <summary>
    /// 是否为推荐商品
    /// </summary>
    public bool IsSuggest { get; set; } = false;

    /// <summary>
    /// 公司Id
    /// </summary>
    public Guid CompanyId { get; set; }

    public bool IsValid { get; set; } = true;

    public Guid DUId { get; set; } = Guid.Empty;

    protected Product()
    {
    }

    public Product(
        Guid id,
        string? code,
        string name,
        Guid? brandId,
        Guid? categoryId,
        string? description,
        bool isSuggest,
        bool isValid,
        Guid companyId) : base(id)
    {
        Code = code;
        Name = name;
        BrandId = brandId;
        CategoryId = categoryId;
        Description = description;
        IsSuggest = isSuggest;
        CompanyId = companyId;
        IsValid = isValid;
    }
}
