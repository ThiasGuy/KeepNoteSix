namespace UserService.Entities
{
    public class UserStoreDatabaseSetting : IUserStoreDatabaseSetting
    {
        public string UserCollectionName { get; set; }
        public string ConnectionString { get; set; } 
        public string DatabaseName { get; set; } 
    }
}
