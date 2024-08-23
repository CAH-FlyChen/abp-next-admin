using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Zion.Product.ProductContext.Dtos;

namespace Zion.Product.ProductContext;

public class DtoHelper : ITransientDependency
{
    public IAbpLazyServiceProvider LazyServiceProvider { get; set; } = default!;

    IBrandRepository _brandRepository => LazyServiceProvider.LazyGetRequiredService<IBrandRepository>();
    ICategoryRepository _categoryRepository => LazyServiceProvider.LazyGetRequiredService<ICategoryRepository>();
    public async Task FillBrandInfoDto(List<ProductDto> dtoList)
    {
        var ids = dtoList.Select(t=>t.BrandId).ToList();
        var brands = await _brandRepository.GetListAsync(t => ids.Contains(t.Id));
        Parallel.ForEach(dtoList, p =>
        {
            if (p.BrandId == null) return;
            var b = brands.SingleOrDefault(t => t.Id == p.BrandId);
            if (b == null) return;
            p.Brand = new BrandSimpleDto { Id = b.Id, Name = b.Name };
        });
    }

    public async Task FillCategoryInfoDto(List<ProductDto> dtoList)
    {
        var categorys = await _categoryRepository.GetListAsync();
        Parallel.ForEach(dtoList, p =>
        {
            if (p.CategoryId == null) return;
            var categoryFullName = getCategroyFullName(categorys, p.CategoryId);
            p.Category = new CategorySimpleDto { Id = (Guid)p.CategoryId, Name = categoryFullName };
        });
    }

    private string getCategroyFullName(List<Category> categories,Guid? categoryId)
    {
        List<string> categoryPathList = new List<string>();
        while(true)
        {
            var category = categories.SingleOrDefault(t=>t.Id==categoryId);
            if (category == null) break;
            categoryPathList.Add(category.Name);
            categoryId = category.ParentId;
        };
        categoryPathList.Reverse();
        return string.Join(" \\ ", categoryPathList);
    }
}
