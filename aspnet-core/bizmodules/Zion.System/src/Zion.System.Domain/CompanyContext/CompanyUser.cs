using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace Zion.System.CompanyContext;


public class CompanyUser : Entity
{
    public Guid CompanyId { get; set; }

    public Guid UserId { get; set; }

    protected CompanyUser()
    {
    }

    public CompanyUser(
        Guid companyId,
        Guid userId
    )
    {
        CompanyId = companyId;
        UserId = userId;
    }

    public override object?[] GetKeys()
    {
        return new object?[] { CompanyId, UserId };
    }
}
