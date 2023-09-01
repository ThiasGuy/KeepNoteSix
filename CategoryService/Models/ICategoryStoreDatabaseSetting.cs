namespace CategoryService.Models
{
    public interface ICategoryStoreDatabaseSetting
    {
        string CategoryCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
