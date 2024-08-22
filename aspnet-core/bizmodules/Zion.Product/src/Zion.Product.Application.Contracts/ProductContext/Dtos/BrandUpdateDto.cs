using System;
using System.ComponentModel;

namespace Zion.Product.ProductContext.Dtos;

/// <summary>
/// 产品品牌
/// </summary>
[Serializable]
public class BrandUpdateDto
{
    /// <summary>
    /// 品牌名称
    /// </summary>
    [DisplayName("BrandName")]
    public string Name { get; set; }

    /// <summary>
    /// 简拼
    /// </summary>
    [DisplayName("BrandJP")]
    public string JP { get; set; }

    /// <summary>
    /// 首字母
    /// </summary>
    [DisplayName("BrandInitialChar")]
    public string InitialChar { get; set; }

    /// <summary>
    /// 品牌图片地址
    /// </summary>
    [DisplayName("BrandImgUrl")]
    public string? ImgUrl { get; set; }
}