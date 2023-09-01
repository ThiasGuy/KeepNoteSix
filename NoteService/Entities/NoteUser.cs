using MongoDB.Bson.Serialization.Attributes;

namespace NoteService.Entities
{
    public class NoteUser
    {
        [BsonId]
        public string UserId { get; set; } 
        public List<Note> Notes { get; set; }
    }
}
