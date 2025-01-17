using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ECF2.Models
{
    public class Statistic
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
    }
}
