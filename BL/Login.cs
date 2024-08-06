using MongoDB.Bson.Serialization.Attributes;

namespace BL
{
    public class Login
    {
        [BsonId]
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
