namespace employeeRecord.Models
{                                                                   //Replicates what is saved into the data base.contains Some data not visible to the User
    public class Employee
    {                                     
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Password { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; } = true;
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }    
    }
}
