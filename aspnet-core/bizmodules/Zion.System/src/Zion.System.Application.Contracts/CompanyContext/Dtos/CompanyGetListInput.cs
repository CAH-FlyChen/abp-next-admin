using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace Zion.System.CompanyContext.Dtos;

[Serializable]
public class CompanyGetListInput : PagedAndSortedResultRequestDto
{
    /// <summary>
    /// 名称
    /// </summary>
    [DisplayName("CompanyName")]
    public string? Name { get; set; }

    /// <summary>
    /// logo Url
    /// </summary>
    [DisplayName("CompanyLogoUrl")]
    public string? LogoUrl { get; set; }

    /// <summary>
    /// 公司简称
    /// </summary>
    [DisplayName("CompanyShortName")]
    public string? ShortName { get; set; }

    /// <summary>
    /// 简拼
    /// </summary>
    [DisplayName("CompanyJP")]
    public string? JP { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    [DisplayName("CompanyStatusCode")]
    public CompanyStatus? StatusCode { get; set; }

    [DisplayName("CompanyDeleteUniqueId")]
    public Guid? DeleteUniqueId { get; set; }

}