using CategoryService.Exceptions;
using CategoryService.Models;
using CategoryService.Repository;

namespace CategoryService.Services
{
    public class categoryService : IcategoryService
    {
        private readonly ICategoryRepo _repo;
        public categoryService(ICategoryRepo repo)
        {
            _repo = repo;
        }

        public Category CreateCategory(Category category)
        {
            try
            {
                var obj = _repo.CreateCategory(category);
                if(obj == null)
                {
                    throw new CategoryNotCreatedException("category Already Exists");
                }
                return obj;
            }
            catch (CategoryNotCreatedException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteCategory(string categoryId)
        {
            try
            {
                var obj = _repo.DeleteCategory(categoryId);
                if(obj == false)
                {
                    throw new CategoryNotFoundException("Category not found");
                }
                return obj;
            }
            catch (CategoryNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Category> GetAllCategoriesByUserId(string userId)
        {
            try
            {
                var result = _repo.GetAllCategoriesByUserId(userId);
                if (result == null)
                {
                    throw new CategoryNotFoundException("This category id not found");
                }

                return result;
            }
            catch (CategoryNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Category GetCategoryById(string categoryId)
        {
            try
            {
                var result = _repo.GetCategoryById(categoryId);
                if (result == null)
                {
                    throw new CategoryNotFoundException("This category id not found");
                }

                return result;
            }
            catch (CategoryNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateCategory(string categoryId, Category category)
        {
            try
            {
                var result = _repo.UpdateCategory(categoryId, category);
                if (!result)
                {
                    throw new CategoryNotFoundException("This category id not found");
                }

                return result;
            }
            catch (CategoryNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
