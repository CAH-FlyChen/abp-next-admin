using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Identity;
using Volo.Abp.Security.Claims;

namespace Zion.System;
public class ZionUserManager : DomainService
{
    IdentityUserManager _userManager => LazyServiceProvider.LazyGetRequiredService<IdentityUserManager>();
    IIdentityRoleRepository _roleRepository => LazyServiceProvider.LazyGetRequiredService<IIdentityRoleRepository>();
    private IIdentityUserRepository _identityUserRepository => LazyServiceProvider.GetRequiredService<IIdentityUserRepository>();
    IOptions<IdentityOptions> identityOptions => LazyServiceProvider.LazyGetRequiredService<IOptions<IdentityOptions>>();
    ICurrentPrincipalAccessor _currentPrincipalAccessor => LazyServiceProvider.LazyGetRequiredService<ICurrentPrincipalAccessor>();
    private IMemoryCache _cache => LazyServiceProvider.GetRequiredService<IMemoryCache>();
    public ZionUserManager() { }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="displayName"></param>
    /// <param name="companyRoles">公司角色</param>
    /// <returns></returns>
    public async Task<IdentityUser> CreateUserWithRolesWithoutSaveAsync(Guid userId, string userName, string displayName, List<string> allowRoleNames, string phoneNumber,string emailEndStr)
    {
        await identityOptions.SetAsync();

        var idu = new IdentityUser(userId, userName, $"{userName}@{emailEndStr}");
        idu.Name = displayName;
        idu.SetPhoneNumber(phoneNumber, true);
        idu.SetPhoneNumberConfirmed(true);

        var roleIds = (await _roleRepository.GetListAsync()).Where(t => allowRoleNames.Contains(t.Name)).Select(t => t.Id).ToList();

        foreach (var role in roleIds)
        {
            idu.AddRole(role);
        }
        return idu;
    }

    public async Task Simulate(Guid userId, Func<Task> action)
    {
        var identityUser = await _userManager.GetByIdAsync(userId);
        var role = await _userManager.GetRolesAsync(identityUser);

        List<Claim> roleClaims = new List<Claim>();
        roleClaims.Add(new Claim(AbpClaimTypes.UserId, userId.ToString()));
        roleClaims.Add(new Claim(AbpClaimTypes.UserName, identityUser.UserName));
        foreach (var r in role)
        {
            roleClaims.Add(new Claim(AbpClaimTypes.Role, r));
        }
        roleClaims.Add(new Claim(AbpClaimTypes.PhoneNumberVerified, "true"));
        roleClaims.Add(new Claim(AbpClaimTypes.PhoneNumber, identityUser.PhoneNumber));
        roleClaims.Add(new Claim(AbpClaimTypes.Name, identityUser.Name));
        var newPrincipal = new ClaimsPrincipal(
            new ClaimsIdentity(
               roleClaims
            )
        );

        using (_currentPrincipalAccessor.Change(newPrincipal))
        {
            await action();
        }
    }

    public async Task<List<IdentityUser>?> GetUserListWithCache()
    {
        var data = await _cache.GetOrCreateAsync("JQRUserListCache", async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
            var r = await _identityUserRepository.GetListAsync();
            return r;
        });
        return data;
    }

}
