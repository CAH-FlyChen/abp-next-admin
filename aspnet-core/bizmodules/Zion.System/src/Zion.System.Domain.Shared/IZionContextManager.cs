using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Users;

namespace Zion.System;

public interface IZionContextManager : ITransientDependency
{
    public Guid? CurrentCompanyId { get; set; }
    public string? CurrentCompanyShortName { get; set; }
    public Guid? CurrentUserId { get; set; }
    public ICurrentUser CurrentUser { get; set; }

    Task Refrash(ICurrentUser currentUser);
}
