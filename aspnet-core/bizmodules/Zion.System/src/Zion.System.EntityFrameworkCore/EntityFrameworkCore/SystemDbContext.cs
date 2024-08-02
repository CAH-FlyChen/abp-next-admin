using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq.Expressions;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;
using Volo.Abp.EntityFrameworkCore;
using Zion.System.CompanyContext;

namespace Zion.System.EntityFrameworkCore;

[ConnectionStringName(SystemDbProperties.ConnectionStringName)]
public class SystemDbContext : AbpDbContext<SystemDbContext>, ISystemDbContext
{
    protected bool IsCompanyIdFilterEnabled => DataFilter?.IsEnabled<IHasCompanyIdFilter>() ?? true;
    protected bool IsValidFilterEnabled => DataFilter?.IsEnabled<IHasIsValid>() ?? true;

    protected ZionContextManager zionCtxManagert => LazyServiceProvider.LazyGetRequiredService<ZionContextManager>();
    protected Guid? CurrentCompanyId => zionCtxManagert.CurrentCompanyId;



    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */
    public DbSet<Company> Companies { get; set; }

    public SystemDbContext(DbContextOptions<SystemDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureSystem();
    }
    protected override Expression<Func<TEntity, bool>> CreateFilterExpression<TEntity>()
    {
        //////copy from base
        //Expression<Func<TEntity, bool>>? expression = null;

        //if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)) && typeof(TEntity).IsAbstract == false)
        //{
        //    expression = e => !IsSoftDeleteFilterEnabled || !EF.Property<bool>(e, "IsDeleted");
        //}

        //if (typeof(IMultiTenant).IsAssignableFrom(typeof(TEntity)))
        //{
        //    Expression<Func<TEntity, bool>> multiTenantFilter = e => !IsMultiTenantFilterEnabled || EF.Property<Guid>(e, "TenantId") == CurrentTenantId;
        //    expression = expression == null ? multiTenantFilter : QueryFilterExpressionHelper.CombineExpressions(expression, multiTenantFilter);
        //}
        //////copy from base end

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
