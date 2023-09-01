using CategoryService.Models;

namespace CategoryService.Services
{
    public interface IcategoryService
    {
        Category CreateCategory(Category category);
        bool DeleteCategory(string categoryId);
        bool UpdateCategory(string categoryId, Category category);
        Category GetCategoryById(string categoryId);
        List<Category> GetAllCategoriesByUserId(string userId);
    }

}
