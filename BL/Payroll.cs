using MongoDB.Bson.Serialization.Attributes;

namespace BL
{
    public class Payroll
    {
        [BsonId]
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal HRA { get; set; }
        public decimal SpecialAllowance { get; set; }
        public decimal PF { get; set; }
        public decimal ESI { get; set; }
        public decimal LWF { get; set; }
        public decimal TDS { get; set; }
        public decimal NetSalary { get; set; }
    }
}
