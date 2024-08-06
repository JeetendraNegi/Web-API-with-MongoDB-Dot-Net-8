
using MongoDB.Bson.Serialization.Attributes;

namespace BL
{
    public class Department
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
