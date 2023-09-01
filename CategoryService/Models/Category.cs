using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CategoryService.Models
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty; 
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("createdby")]
        public string CreatedBy { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("creationdate")]
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
