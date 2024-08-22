using System;
using System.ComponentModel;

namespace Zion.Product.ProductContext.Dtos;

[Serializable]
public class BrandCreateDto
{
    /// <summary>
    /// 品牌名称
    /// </summary>
    [DisplayName("BrandName")]
    public string Name { get; set; }

    /// <summary>
    /// 品牌图片地址
    /// </summary>
    [DisplayName("BrandImgUrl")]
    public string? ImgUrl { get; set; }
}