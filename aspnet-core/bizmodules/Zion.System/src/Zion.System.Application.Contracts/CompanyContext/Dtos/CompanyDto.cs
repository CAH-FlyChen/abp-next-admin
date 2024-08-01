using System;
using Volo.Abp.Application.Dtos;

namespace Zion.System.CompanyContext.Dtos;

[Serializable]
public class CompanyDto : FullAuditedEntityDto<Guid>
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// logo Url
    /// </summary>
    public string? LogoUrl { get; set; }

    /// <summary>
    /// 公司简称
    /// </summary>
    public string ShortName { get; set; }

    /// <summary>
    /// 简拼
    /// </summary>
    public string JP { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public CompanyStatus StatusCode { get; set; }

    ///// <summary>
    ///// 公司下的用户
    ///// </summary>
    //public List<CompanyUser>? CompanyUsers { get; set; }

    public Guid DeleteUniqueId { get; set; }

    public CompanyLocationDto CompanyLocation { get; set; }
}