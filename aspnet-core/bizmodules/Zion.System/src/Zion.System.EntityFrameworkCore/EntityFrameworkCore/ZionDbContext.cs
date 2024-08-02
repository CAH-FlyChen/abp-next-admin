using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore;

namespace Zion.System.EntityFrameworkCore;
public class ZionDbContext<TDbContext> : AbpDbContext<TDbContext> where TDbContext : DbContext
{
    protected bool IsCompanyIdFilterEnabled => DataFilter?.IsEnabled<IHasCompanyIdFilter>() ?? true;
    protected bool IsValidFilterEnabled => DataFilter?.IsEnabled<IHasIsValid>() ?? true;

    protected ZionContextManager zionCtxManagert => LazyServiceProvider.LazyGetRequiredService<ZionContextManager>();
    protected Guid? CurrentCompanyId => zionCtxManagert.CurrentCompanyId;

    public ZionDbContext(DbContextOptions<TDbContext> options)
    : base(options)
    {

    }

    protected override Expression<Func<TEntity, bool>> CreateFilterExpression<TEntity>()
    {
        var expression = base.CreateFilterExpression<TEntity>();

        if (typeof(IHasCompanyIdFilter).IsAssignableFrom(typeof(TEntity)))
        {
            Expression<Func<TEntity, bool>> companyIdFilter = e => !IsCompanyIdFilterEnabled || EF.Property<Guid>(e, "CompanyId") == CurrentCompanyId;
            expression = expression == null
            ? companyIdFilter
            : QueryFilterExpressionHelper.CombineExpressions(expression, companyIdFilter);
        }

        if (typeof(IHasIsValid).IsAssignableFrom(typeof(TEntity)))
        {
            Expression<Func<TEntity, bool>> isValidIdFilter = e => !IsValidFilterEnabled || EF.Property<bool>(e, "IsValid") == true;
            expression = expression == null
            ? isValidIdFilter
            : QueryFilterExpressionHelper.CombineExpressions(expression, isValidIdFilter);
        }

        return expression!;
    }
    protected override void ApplyAbpConceptsForDeletedEntity(EntityEntry entry)
    {
        //base.ApplyAbpConceptsForDeletedEntity(entry);

        if (entry.Entity is ISoftDelete && !IsHardDeleted(entry))
        {
            entry.Reload();
            ObjectHelper.TrySetProperty(entry.Entity.As<ISoftDelete>(), (ISoftDelete x) => x.IsDeleted, () => true);
            if (entry.Entity is IHasDeleteUniqueId e)
            {
                var e1 = entry.Entity as IEntity<Guid>;
                if (e1 != null)
                {
                    ObjectHelper.TrySetProperty(e.As<IHasDeleteUniqueId>(), (IHasDeleteUniqueId x) => x.DUId, () => e1.Id);
                }
            }

            SetDeletionAuditProperties(entry);
        }
    }
}
