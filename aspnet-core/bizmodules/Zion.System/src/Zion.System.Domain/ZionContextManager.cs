using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Uow;
using Volo.Abp.Users;
using Zion.System.CompanyContext;

namespace Zion.System;

public class ZionContextManager : IZionContextManager
{
    public Guid? CurrentCompanyId { get; set; }
    public string? CurrentCompanyShortName { get; set; }
    public Guid? CurrentUserId { get; set; }

    public ICurrentUser CurrentUser { get; set; }

    IMemoryCache _cahce;
    private ICompanyRepository companyRepository { get; set; }

    public ZionContextManager(IMemoryCache cahce, ICompanyRepository companyRepository, ICurrentUser currentUser)
    {
        _cahce = cahce;
        CurrentUser = currentUser;
        CurrentUserId = currentUser.Id == null ? null : currentUser.Id.Value;
        this.companyRepository = companyRepository;
        InitAsync(currentUser).GetAwaiter().GetResult();
    }
    [UnitOfWork]
    public virtual async Task InitAsync(ICurrentUser currentUser)
    {
        if (currentUser == null) return;

        await SetCompany(currentUser);
    }

    public async Task Refrash(ICurrentUser currentUser)
    {
        if (currentUser == null) return;
        _cahce.Remove("UserCompany_" + currentUser.Id.ToString());

        await SetCompany(currentUser);
    }

    public class CompanyCacheItem
    {
        public Guid CompanyId { get; set; }
        public string ShortName { get; set; }
    }

    private async Task SetCompany(ICurrentUser currentUser)
    {
        var x = await _cahce.GetOrCreateAsync("UserCompany_" + currentUser.Id.ToString(), async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60);
            var d = (await companyRepository.WithDetailsAsync(t => t.CompanyUsers))
                    .Single(t => t.CompanyUsers.Any(u => u.UserId == currentUser.Id))
                    ;
            return new CompanyCacheItem { CompanyId = d.Id, ShortName = d.ShortName };
        });

        //if(item == null) {
        //    throw new BizException("该用户未找到所属公司");
        //}
        //未登录的时候就是空
        CurrentCompanyId = x?.CompanyId;
        CurrentCompanyShortName = x?.ShortName;
    }

}
