using MongoDB.Bson.Serialization.Attributes;

namespace BL
{
    public class Employee
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public Address Address { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
