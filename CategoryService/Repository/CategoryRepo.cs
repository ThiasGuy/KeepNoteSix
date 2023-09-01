using CategoryService.Models;
using MongoDB.Driver;

namespace CategoryService.Repository
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly IMongoCollection<Category> _categories;

        public CategoryRepo(ICategoryStoreDatabaseSetting setting)
        {
            var client = new MongoClient(setting.ConnectionString);
            var database = client.GetDatabase(setting.DatabaseName);
            _categories = database.GetCollection<Category>(setting.CategoryCollectionName);
        }
        public Category CreateCategory(Category category)
        {
            _categories.InsertOne(category);
            return category;
        }

        public bool DeleteCategory(string categoryId)
        {
            var obj = _categories.Find(x => x.Id == categoryId).FirstOrDefault();
            if(obj == null)
            {
                return false;
            }
            var result = _categories.DeleteOne(Builders<Category>.Filter.Eq("categoryId", categoryId));
            return true;
        }

        public List<Category> GetAllCategoriesByUserId(string userId)
        {
            var obj = _categories.Find(x => x.CreatedBy == userId).ToList();
            if(obj == null)
            {
                return null;
            }
            return obj;
        }

        public Category GetCategoryById(string categoryId)
        {
            var obj = _categories.Find(x => x.Id == categoryId).FirstOrDefault();
            if (obj == null)
                return null;
            return obj;
        }

        public bool UpdateCategory(string categoryId, Category category)
        {
            var filter = Builders<Category>.Filter.Eq("CategoryId", categoryId);
            var result = _categories.ReplaceOne(filter, category);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}
