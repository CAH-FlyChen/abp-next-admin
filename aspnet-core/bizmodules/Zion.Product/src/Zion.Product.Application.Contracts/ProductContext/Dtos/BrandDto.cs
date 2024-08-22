using System;
using Volo.Abp.Application.Dtos;

namespace Zion.Product.ProductContext.Dtos;

/// <summary>
/// 产品品牌
/// </summary>
[Serializable]
public class BrandDto : FullAuditedEntityDto<Guid>
{
    /// <summary>
    /// 品牌名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 简拼
    /// </summary>
    public string JP { get; set; }

    /// <summary>
    /// 首字母
    /// </summary>
    public string InitialChar { get; set; }

    /// <summary>
    /// 品牌图片地址
    /// </summary>
    public string? ImgUrl { get; set; }
}