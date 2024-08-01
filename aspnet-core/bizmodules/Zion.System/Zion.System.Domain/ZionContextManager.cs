using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Uow;
using Volo.Abp.Users;

namespace Zion.System;

public class ZionContextManager : IZionContextManager
{
    public Guid? CurrentCompanyId { get; set; }
    public string? CurrentCompanyShortName { get; set; }
    public Guid? CurrentUserId { get; set; }

    public ICurrentUser CurrentUser { get; set; }

    IMemoryCache _cahce;
    private ICompanyRepository CompanyRepository { get; set; }
    private ICompanyUserRepository CompanyUserRepository { get; set; }

    public ZionContextManager(IMemoryCache cahce, ICompanyRepository companyRepository, ICompanyUserRepository companyUserRepository, ICurrentUser currentUser)
    {
        _cahce = cahce;
        CurrentUser = currentUser;
        CurrentUserId = currentUser.Id == null ? null : currentUser.Id.Value;
        CompanyRepository = companyRepository;
        CompanyUserRepository = companyUserRepository;
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


    private async Task SetCompany(ICurrentUser currentUser)
    {
        var x = await _cahce.GetOrCreateAsync("UserCompany_" + currentUser.Id.ToString(), async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60);
            var companyRelQ = await CompanyUserRepository.GetQueryableAsync();
            var companyQ = await CompanyRepository.GetQueryableAsync();
            var q = from a in companyRelQ
                    join b in companyQ on a.CompanyId equals b.Id
                    where a.UserId == currentUser.Id
                    select new { a.CompanyId, b.ShortName };
            var d = q.SingleOrDefault();
            return d;
        });

        //if(item == null) {
        //    throw new BizException("该用户未找到所属公司");
        //}
        //未登录的时候就是空
        CurrentCompanyId = x?.CompanyId;
        CurrentCompanyShortName = x?.ShortName;
    }

}
