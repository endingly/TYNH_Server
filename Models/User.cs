using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TYNH_server.Models
{
    public class User : BaseModel
    {
        public string gender { get; set; }

        public string name { get; set; }

        public string college { get; set; }

        public string grade { get; set; }

        public string major { get; set; }
    }
}