using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TYNH_server.Models
{
    public class BaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
    }
}