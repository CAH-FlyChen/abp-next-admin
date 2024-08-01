using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using NPinyin;

namespace Zion.System.CompanyContext;

public class Company : FullAuditedAggregateRoot<Guid>
{
    /// <summary>
    /// 名称
    /// </summary>
    [MaxLength(50)]
    [Required]
    [Description("名称")]
    public string Name { get; set; }

    /// <summary>
    /// logo Url
    /// </summary>
    [MaxLength(500)]
    [Description("Logo Url")]
    public string? LogoUrl { get; set; }

    /// <summary>
    /// 公司简称
    /// </summary>
    [MaxLength(50)]
    [Description("公司简称")]
    public string ShortName { get; set; }

    /// <summary>
    /// 简拼
    /// </summary>
    [MaxLength(50)]
    public string JP { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public CompanyStatus StatusCode { get; set; }
    /// <summary>
    /// 公司下的用户
    /// </summary>
    public List<CompanyUser>? CompanyUsers { get; set; }

    public Guid DeleteUniqueId { get; set; } = Guid.Empty;

    public CompanyLocation CompanyLocation { get; set; }

    protected Company()
    {
    }

    public Company(
        Guid id,
        string name,
        string? logoUrl,
        string shortName,
        List<CompanyUser> companyUsers,
        CompanyLocation companyLocation
    ) : base(id)
    {
        Name = name;
        LogoUrl = logoUrl;
        ShortName = shortName;
        JP = Pinyin.GetInitials(shortName).ToLower();
        StatusCode = CompanyStatus.有效;
        CompanyUsers = companyUsers;
        CompanyLocation = companyLocation;
    }

    public void AddUser(Guid userId)
    {
        CompanyUsers!.Add(new CompanyUser(GloableGuidGenerator.Create(), userId));
    }
}
