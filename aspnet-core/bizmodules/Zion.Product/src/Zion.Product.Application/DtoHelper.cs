using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Zion.Product.ProductContext.Dtos;
using static Zion.Product.Permissions.ProductPermissions;

namespace Zion.Product.ProductContext;

public class DtoHelper : ITransientDependency
{
    public IAbpLazyServiceProvider LazyServiceProvider { get; set; } = default!;

    IBrandRepository _brandRepository => LazyServiceProvider.LazyGetRequiredService<IBrandRepository>();
    ICategoryRepository _categoryRepository => LazyServiceProvider.LazyGetRequiredService<ICategoryRepository>();
    IProductRepository _productRepository => LazyServiceProvider.LazyGetRequiredService<IProductRepository>();

    public async Task FillProductDto(List<GetCategoryTreeResultItemDto> data)
    {
        var categoryList = await _categoryRepository.GetListAsync();
        var products = (await _productRepository.GetListAsync(t => t.IsSuggest))
            .Select(t=> new { Code = t.Code, Description = t.Description, ImageUrl = t.ImageUrl, Name = t.Name, Id = t.Id, CategoryId=t.CategoryId, CategoryIds = GetCategoryPath(categoryList, t.CategoryId) })
            .ToList();

        foreach (var categoryItem in data)//只设置rootlevel
        {
            var productsInCategory = products.Where(t => t.CategoryIds.Contains(categoryItem.Id) ).Select(t => new ProductSimpleDto() {Code=t.Code,Description=t.Description,ImageUrl=t.ImageUrl,Name=t.Name,CategoryId=t.CategoryId } ).ToList();
            categoryItem.Products = productsInCategory;
        }
    }

    private List<Guid> GetCategoryPath(List<Category> categoryList,Guid? categoryId)
    {
        var ids = new List<Guid>();

        if (categoryId == null) return ids;

        ids.Add(categoryId.Value);

        var category = categoryList.SingleOrDefault(t=>t.Id == categoryId);
        if (category != null)
        {
            ids.AddRange(GetCategoryPath(categoryList, category.ParentId));
        }

        return ids;

    }

    private List<Guid> GetCategoryIds(List<GetCategoryTreeResultItemDto> data)
    {
        var ids = new List<Guid>();
        foreach (var item in data)
        {
            ids.Add(item.Id);
            ids.AddRange(GetCategoryIds(item.Children));
        }
        return ids;
    }

    private void FillDtoProduct(List<GetCategoryTreeResultItemDto> r, List<Product> products)
    {
        if (r == null || r.Count == 0) return;

        foreach (var categoryItem in r)
        {
            categoryItem.Products = products.Where(t => t.CategoryId == categoryItem.Id).Select(t => new ProductSimpleDto() { Code = t.Code, Description = t.Description, ImageUrl = t.ImageUrl, Name = t.Name, Id = t.Id }).ToList();
            FillDtoProduct(categoryItem.Children, products);
        }
    }


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

    public async Task FillCategoryListDto(List<ProductDto> dtoList)
    {
        var categorys = await _categoryRepository.GetListAsync();
        Parallel.ForEach(dtoList, p =>
        {
            if (p.CategoryId == null) return;
            var categoryList = getCategroys(categorys, p.CategoryId);
            p.CategoryList = categoryList.Select(t=>new CategorySimpleDto() {Id=t.Id,Name=t.Name }).Reverse().ToList();
        });
    }

    private List<Category> getCategroys(List<Category> categories, Guid? categoryId)
    {
        List<Category> categoryList = new List<Category>();
        while (true)
        {
            var category = categories.SingleOrDefault(t => t.Id == categoryId);
            if (category == null) break;
            categoryList.Add(category);
            categoryId = category.ParentId;
        };
        return categoryList;
    }
}
