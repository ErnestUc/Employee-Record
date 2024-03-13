namespace employeeRecord.DTOs
{
    public class CreateAccountDTO                   //collects Customer Data to be added to the Data base or Stored in the system
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
