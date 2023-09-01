﻿namespace UserService.Entities
{
    public interface IUserStoreDatabaseSetting
    {
        string UserCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
