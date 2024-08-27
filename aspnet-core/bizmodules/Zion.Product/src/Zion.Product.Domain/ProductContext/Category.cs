using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Zion.System;

namespace Zion.Product.ProductContext;

public class Category : FullAuditedAggregateRoot<Guid>, IHasDeleteUniqueId
{
    /// <summary>
    /// 名称
    /// </summary>
    [MaxLength(100)]
    [Required]
    public string Name { get; set; }
    /// <summary>
    /// 等级
    /// </summary>
    [Required]
    public int Level { get; protected set; } = 0;

    public Guid? ParentId { get; protected set; }

    [MaxLength(4000)]
    public string? ImageUrl { get; set; }
    /// <summary>
    /// 上级分类
    /// </summary>
    public virtual Category? Parent { get; set; }
    public virtual ICollection<Category>? Children { get; set; }

    public Guid DUId { get; set; } = Guid.Empty;



    public void CheckCanDelete()
    {
        if (Children == null) return;
        if (Children.Count == 0) return;
        throw new BusinessException($"分类[{Id}:{Name}]有子项，不能删除。请先删除子项。");
    }

    public void CreateRootItem(string name)
    {
        Name = name;
        Level = 0;
        ParentId = null;
    }
    /// <summary>
    /// 添加子项
    /// </summary>
    /// <param name="catalog"></param>
    public void AddChildItem(Category catalog)
    {
        if (Children == null)
            Children = new List<Category>();
        catalog.Level = Level + 1;
        catalog.ParentId = Id;
        Children.Add(catalog);
    }

    protected Category()
    {
    }

    public Category(
        Guid id,
        string name,
        int level,
        Guid? parentId,
        string? imageUrl,
        Category? parent,
        ICollection<Category>? children,
        Guid dUId
    ) : base(id)
    {
        Name = name;
        Level = level;
        ParentId = parentId;
        ImageUrl = imageUrl;
        Parent = parent;
        Children = children;
        DUId = dUId;
    }
}
