using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using NPinyin;

namespace Zion.Product.ProductContext;

/// <summary>
/// 产品品牌
/// </summary>
public class Brand : FullAuditedAggregateRoot<Guid>
{
    /// <summary>
    /// 品牌名称
    /// </summary>
    [Required(ErrorMessage = "品牌名称不能为空")]
    [MaxLength(100)]
    public string Name { get; private set; }
    /// <summary>
    /// 简拼
    /// </summary>
    [Required(ErrorMessage = "简拼不能为空")]
    [MaxLength(10)]
    public string JP { get; private set; }
    /// <summary>
    /// 首字母
    /// </summary>
    [Required(ErrorMessage = "首字母不能为空")]
    [MaxLength(1)]
    public string InitialChar { get; private set; }
    /// <summary>
    /// 品牌图片地址
    /// </summary>
    [MaxLength(2000)]
    public string? ImgUrl { get; private set; }

    protected Brand()
    {
    }

    public Brand(
        Guid id,
        string name,
        string? imgUrl
    ) : base(id)
    {
        Name = name;
        ImgUrl = imgUrl;

        JP = Pinyin.GetInitials(name);
        InitialChar = "";
        if (JP.Length >= 1)
        {
            InitialChar = JP.First().ToString();
        }
    }

    public void Update(
        string name,
        string jp,
        string initialChar,
        string? imgUrl
    )
    {
        Name = name;
        JP = jp;
        InitialChar = initialChar;
        ImgUrl = imgUrl;
    }

}
