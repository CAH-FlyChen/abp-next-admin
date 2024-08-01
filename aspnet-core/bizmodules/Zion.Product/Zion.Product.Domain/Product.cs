using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Zion.Product;

/// <summary>
/// 产品
/// </summary>
public class Product : FullAuditedAggregateRoot<Guid>, IHasCompanyIdFilter, IHasDeleteUniqueId, IHasCompanyUniqueCode, IHasIsValid
{
    /// <summary>
    /// 自有唯一编码
    /// </summary>
    [MaxLength(100)]
    public string Code { get; set; }

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
    /// 描述
    /// </summary>
    [MaxLength(2000)]
    public string? Description { get; set; }

    /// <summary>
    /// 公司Id
    /// </summary>
    public Guid CompanyId { get; set; }
    /// <summary>
    /// 产品分类代码
    /// </summary>
    public Guid? CategoryLevelCode { get; set; }
    /// <summary>
    /// 单位Id
    /// </summary>
    [MaxLength(100)]
    public Guid? UnitId { get; set; }
    /// <summary>
    /// 是否有效
    /// </summary>
    public bool IsValid { get; set; } = true;
    /// <summary>
    /// 删除唯一码
    /// </summary>
    public Guid DeleteUniqueId { get; set; } = Guid.Empty;

    protected Product() { }

    public Product(Guid id, string code, string name, Guid? brandId, string? description, Guid? categoryLevelCode, Guid? unitId, Guid companyId)
        : base(id)
    {
        Code = code;
        Name = name;
        BrandId = brandId;
        Description = description;
        CompanyId = companyId;
        CategoryLevelCode = categoryLevelCode;
        UnitId = unitId;
        IsValid = true;
    }
}
