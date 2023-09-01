using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace NoteService.Entities
{
    public class Note
    {
        [BsonId]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Category? Category { get; set; } = null;
        public List<Reminder>? Reminders { get; set; } = null;
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
