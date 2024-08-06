using BL;

namespace EMS.DTOs
{
    public class EmployeeLoginDTO
    {
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string DepartmentName { get; set; }
        public Address Address { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public int BasicSalary { get; set; }
        public int NetSalary { get; set; }
    }
}
