using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using System.Linq.Dynamic.Core;
using Volo.Abp.Data;
using Zion.System;

namespace Zion.AppService;

public abstract class ZionCrudAppService<TEntity, TEntityDto, TKey>
    : ZionCrudAppService<TEntity, TEntityDto, TKey, PagedAndSortedResultRequestDto>
    where TEntity : class, IEntity<TKey>
    where TEntityDto : IEntityDto<TKey>
{
    protected ZionCrudAppService(IRepository<TEntity, TKey> repository)
        : base(repository)
    {

    }
}

public abstract class ZionCrudAppService<TEntity, TEntityDto, TKey, TGetListInput>
    : ZionCrudAppService<TEntity, TEntityDto, TKey, TGetListInput, TEntityDto>
    where TEntity : class, IEntity<TKey>
    where TEntityDto : IEntityDto<TKey>
{
    protected ZionCrudAppService(IRepository<TEntity, TKey> repository)
        : base(repository)
    {

    }
}

public abstract class ZionCrudAppService<TEntity, TEntityDto, TKey, TGetListInput, TCreateInput>
    : ZionCrudAppService<TEntity, TEntityDto, TKey, TGetListInput, TCreateInput, TCreateInput>
    where TEntity : class, IEntity<TKey>
    where TEntityDto : IEntityDto<TKey>
{
    protected ZionCrudAppService(IRepository<TEntity, TKey> repository)
        : base(repository)
    {

    }
}
//6-7
public abstract class ZionCrudAppService<TEntity, TEntityDto, TKey, TGetListInput, TCreateInput, TUpdateInput>
                    : ZionCrudAppService<TEntity, TEntityDto, TEntityDto, TKey, TGetListInput, TCreateInput, TUpdateInput>
    where TEntity : class, IEntity<TKey>
    where TEntityDto : IEntityDto<TKey>
{

    protected ZionCrudAppService(IRepository<TEntity, TKey> repository)
        : base(repository)
    {
    }

    protected virtual IQueryable<T> ApplySorting<T>(IQueryable<T> query, TGetListInput input)
    {
        //Try to sort query if available
        if (input is ISortedResultRequest sortInput)
        {
            if (!sortInput.Sorting.IsNullOrWhiteSpace())
            {
                return query.OrderBy(sortInput.Sorting!);
            }
        }

        //IQueryable.Task requires sorting, so we should sort if Take will be used.
        if (input is ILimitedResultRequest)
        {
            return ApplyDefaultSorting<T>(query);
        }

        //No sorting
        return query;
    }

    protected virtual IQueryable<T> ApplyPaging<T>(IQueryable<T> query, TGetListInput input)
    {
        //Try to use paging if available
        if (input is IPagedResultRequest pagedInput)
        {
            return query.PageBy(pagedInput);
        }

        //Try to limit query result if available
        if (input is ILimitedResultRequest limitedInput)
        {
            return query.Take(limitedInput.MaxResultCount);
        }

        //No paging
        return query;
    }

    //protected IHasCompanyName CheckImplementIHasCompanyName(Entity<Guid> entity)
    //{
    //    IHasCompanyName? c = entity! as IHasCompanyName;
    //    if (c == null)
    //        throw new BizException($"实体未实现IhasCompanyName接口");
    //    return c;
    //}

    //protected void CheckEntityIsNotNull(Entity<Guid> entity, Guid id)
    //{
    //    if (entity == null)
    //        throw new BizException($"未找到Id为{id}的对象");
    //}
}



//7-9
public abstract class ZionCrudAppService<TEntity, TGetOutputDto, TGetListOutputDto, TKey, TGetListInput, TCreateInput, TUpdateInput>
    : ZionCrudAppService<TEntity, TGetOutputDto, TGetListOutputDto, TKey, TGetListInput, TCreateInput, TGetOutputDto, TUpdateInput, TGetOutputDto>
    where TEntity : class, IEntity<TKey>
    where TGetOutputDto : IEntityDto<TKey>
    where TGetListOutputDto : IEntityDto<TKey>
{

    //public DtoManager _dtoManager => LazyServiceProvider.LazyGetRequiredService<DtoManager>();

    protected ZionCrudAppService(IRepository<TEntity, TKey> repository)
    : base(repository)
    {

    }

    //protected override Task<TEntityDto> MapToGetListOutputDtoAsync(TEntity entity)
    //{
    //    return MapToGetOutputDtoAsync(entity);
    //}

    //protected override TEntityDto MapToGetListOutputDto(TEntity entity)
    //{
    //    return MapToGetOutputDto(entity);
    //}
}



//7-8
public abstract class ZionCrudAppService<TEntity, TGetOutputDto, TGetListOutputDto, TKey, TGetListInput, TCreateInput, TCreateOutputDto, TUpdateInput, TUpdateOutputDto>
    : ZionAbstractKeyCrudAppService<TEntity, TGetOutputDto, TGetListOutputDto, TKey, TGetListInput, TCreateInput, TCreateOutputDto, TUpdateInput, TUpdateOutputDto>
    where TEntity : class, IEntity<TKey>
    where TGetOutputDto : IEntityDto<TKey>
    where TGetListOutputDto : IEntityDto<TKey>
    where TCreateOutputDto : IEntityDto<TKey>
    where TUpdateOutputDto : IEntityDto<TKey>
{
    protected new IRepository<TEntity, TKey> Repository { get; }
    ZionUserManager _userManager => LazyServiceProvider.GetRequiredService<ZionUserManager>();
    public IZionContextManager ZionContext {
        get {
            return LazyServiceProvider.GetRequiredService<ZionContextManager>();
        }
    }
    public IDataFilter dataFilter => LazyServiceProvider.GetRequiredService<IDataFilter>();

    protected ZionCrudAppService(IRepository<TEntity, TKey> repository)
        : base(repository)
    {
        Repository = repository;
    }

    protected override async Task DeleteByIdAsync(TKey id)
    {
        await Repository.DeleteAsync(id);
    }

    protected override async Task<TEntity> GetEntityByIdAsync(TKey id)
    {
        var r = await Repository.GetAsync(id);


        return r;
    }

    public override async Task<PagedResultDto<TGetListOutputDto>> GetListAsync(TGetListInput input)
    {
        var r = await base.GetListAsync(input);
        foreach (var x in r.Items)
        {
            if (x is IHasCreatorWithName)
            {
                var r0 = x as IHasCreatorWithName;
                await this.TryFillCreatorName(r0);
            }
            if (x is IHasLastModifierWithName)
            {
                var r0 = x as IHasLastModifierWithName;
                await this.TryFillLastModifierName(r0);
            }
        }
        return r;
    }

    public override async Task<TGetOutputDto> GetAsync(TKey id)
    {
        await CheckGetPolicyAsync();

        var entity = await Repository.GetAsync(id, true);

        var r = await MapToGetOutputDtoAsync(entity);

        if (r is IHasCreatorWithName)
        {
            var r0 = r as IHasCreatorWithName;
            await this.TryFillCreatorName(r0);
        }
        if (r is IHasLastModifierWithName)
        {
            var r0 = r as IHasLastModifierWithName;
            await this.TryFillLastModifierName(r0);
        }
        return r;
    }



    protected override void MapToEntity(TUpdateInput updateInput, TEntity entity)
    {
        if (updateInput is IEntityDto<TKey> entityDto)
        {
            entityDto.Id = entity.Id;
        }

        base.MapToEntity(updateInput, entity);
    }

    protected override IQueryable<TEntity> ApplyDefaultSorting(IQueryable<TEntity> query)
    {
        if (typeof(TEntity).IsAssignableTo<IHasCreationTime>())
        {
            return query.OrderByDescending(e => ((IHasCreationTime)e).CreationTime);
        }
        else
        {
            return query.OrderByDescending(e => e.Id);
        }
    }


    protected async Task TryFillCreatorName<T>(List<T> entityDtoList) where T : IHasCreatorWithName
    {
        foreach (var entityDto in entityDtoList)
        {
            if (entityDto.CreatorId == null) continue;
            await TryFillCreatorName(entityDto);
        }
    }

    protected async Task TryFillLastModifierName<T>(List<T> entityDtoList) where T : IHasLastModifierWithName
    {
        foreach (var entityDto in entityDtoList)
        {
            if (entityDto.LastModifierId == null) continue;
            await TryFillLastModifierName(entityDto);
        }
    }

    protected async Task TryFillCreatorName<T>(T entityDto) where T : IHasCreatorWithName?
    {
        if (entityDto == null) return;
        if (entityDto.CreatorId == null) return;
        var identityUserCache = await _userManager.GetUserListWithCache();
        if (identityUserCache == null) return;
        var creatorUserDto = identityUserCache.SingleOrDefault(t => t.Id == (Guid)entityDto.CreatorId);
        entityDto.CreatorName = creatorUserDto?.Name!;
    }

    protected async Task TryFillLastModifierName<T>(T entityDto) where T : IHasLastModifierWithName?
    {
        if (entityDto == null) return;
        if (entityDto.LastModifierId == null) return;
        var identityUserCache = await _userManager.GetUserListWithCache();
        if (identityUserCache == null) return;
        var creatorUserDto = identityUserCache.SingleOrDefault(t => t.Id == (Guid)entityDto.LastModifierId);
        entityDto.LastModifierName = creatorUserDto?.Name!;
    }


    protected virtual IQueryable<T> ApplyObjSorting<T>(IQueryable<T> query, IPagedAndSortedResultRequest input)
    {
        //Try to sort query if available
        if (input is ISortedResultRequest sortInput)
        {
            if (!sortInput.Sorting.IsNullOrWhiteSpace())
            {
                return query.OrderBy(sortInput.Sorting!);
            }
        }

        //IQueryable.Task requires sorting, so we should sort if Take will be used.
        if (input is ILimitedResultRequest)
        {
            return ApplyDefaultSorting<T>(query);
        }

        //No sorting
        return query;
    }


    protected virtual IQueryable<T> ApplyObjSorting<T>(IQueryable<T> query, TGetListInput input)
    {
        //Try to sort query if available
        if (input is ISortedResultRequest sortInput)
        {
            if (!sortInput.Sorting.IsNullOrWhiteSpace())
            {
                return query.OrderBy(sortInput.Sorting!);
            }
            else
            {
                return query.OrderBy("CreationTime desc");
            }
        }

        //IQueryable.Task requires sorting, so we should sort if Take will be used.
        if (input is ILimitedResultRequest)
        {
            return ApplyDefaultSorting<T>(query);
        }

        //No sorting
        return query;
    }
    protected virtual IQueryable<T> ApplyDefaultSorting<T>(IQueryable<T> query)
    {
        if (typeof(TEntity).IsAssignableTo<IHasCreationTime>())
        {
            return query.OrderBy("CreationTime desc");
        }

        throw new AbpException("No sorting specified but this query requires sorting. Override the ApplySorting or the ApplyDefaultSorting method for your application service derived from AbstractKeyReadOnlyAppService!");
    }
    protected virtual IQueryable<T> ApplyObjPaging<T>(IQueryable<T> query, TGetListInput input)
    {
        //Try to use paging if available
        if (input is IPagedResultRequest pagedInput)
        {
            return query.PageBy(pagedInput);
        }

        //Try to limit query result if available
        if (input is ILimitedResultRequest limitedInput)
        {
            return query.Take(limitedInput.MaxResultCount);
        }

        //No paging
        return query;
    }
    protected virtual IQueryable<T> ApplyObjPaging<T>(IQueryable<T> query, IPagedAndSortedResultRequest input)
    {
        //Try to use paging if available
        if (input is IPagedResultRequest pagedInput)
        {
            return query.PageBy(pagedInput);
        }

        //Try to limit query result if available
        if (input is ILimitedResultRequest limitedInput)
        {
            return query.Take(limitedInput.MaxResultCount);
        }

        //No paging
        return query;
    }
}





