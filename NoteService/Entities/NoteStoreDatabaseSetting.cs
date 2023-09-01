namespace NoteService.Entities
{
    public class NoteStoreDatabaseSetting : INoteStoreDatabaseSetting
    {
        public string NoteCollectionName { get; set; }
        public string UserCollectionName { get; set; }
        public string ConnectionString { get; set ; }
        public string DatabaseName { get; set; }
    }
}
