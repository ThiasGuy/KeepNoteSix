using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UserService.Entities
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; } = string.Empty;
        [BsonElement("username")]
        public string Name { get; set; }
        [BsonElement("contact")]
        public string Contact { get; set; }
        [BsonElement("date")]
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;
    }
}
