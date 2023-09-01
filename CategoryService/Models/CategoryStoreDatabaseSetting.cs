namespace CategoryService.Models
{
    public class CategoryStoreDatabaseSetting : ICategoryStoreDatabaseSetting
    {
        public string CategoryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set ; }
    }
}
