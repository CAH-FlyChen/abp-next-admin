using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace Zion.System.CompanyContext;

public class CompanyUser: Entity
{
    public Guid CompanyId { get; set; }
    public Guid UserId { get; set; }

    public virtual Company Company { get; set; }
    //public virtual IdentityUser User { get; set; }

    public override object?[] GetKeys()
    {
        return new object?[] { CompanyId, UserId };
    }

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
}
