namespace NoteService.Entities
{
    public interface INoteStoreDatabaseSetting
    {
        string NoteCollectionName { get; set; }
        string UserCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
