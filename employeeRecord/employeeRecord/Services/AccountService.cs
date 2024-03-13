using employeeRecord.DTOs;
using employeeRecord.Interface;
using employeeRecord.Models;
//using System.Linq.Expressions;

namespace employeeRecord.Services                    
{
    public class AccountService : IAccountService      //The main class that interacts with the data base Where you implement the Interface
    {
        private static List<Employee> employees = new List<Employee>   //Populate data from the Model(Account) replicated database where data will be fetched from. Mimicking how the data base works.
         {
            new Employee{
                         EmployeeId = Guid.NewGuid().ToString(),//gives each of the record a Unique ID
                        FirstName = "Ernest",
                        LastName = "Uchenna",
                        Email = "Ernestazbuike482@gamil.com",
                        Password = 1234,
                        PhoneNumber = "08101540593",
                        Address = "Ogba Ikeja",
                        CreatedAt= DateTime.Now,
                        LastModifiedAt = DateTime.Now,
                        IsActive = true
            },
             new Employee{
                        EmployeeId = Guid.NewGuid().ToString(),
                        FirstName = "Emma",
                        LastName = "Nelson",
                        Email = "NelsonAmaechi@gamil.com",
                        Password = 4321,
                        PhoneNumber = "0811234242",
                        Address = "Abuja",
                        CreatedAt= DateTime.Now,
                        LastModifiedAt = DateTime.Now,
                        IsActive = true
            },
             new Employee{
                        EmployeeId= Guid.NewGuid().ToString(), 
                        FirstName = "Chisom",
                        LastName = "Azubuike",
                        Email = "BestGuy@gamil.com",
                        Password = 4321,
                        PhoneNumber = "0832434242",
                        Address = "Portharcourt",
                        CreatedAt= DateTime.Now,
                        LastModifiedAt = DateTime.Now,
                        IsActive = true
            },
         };
    public AccountService()
        {
            
        }

        public async Task<dynamic> CreateAccountAsync(CreateAccountDTO payload)  //implemented interface for Post record
        {
            var serviceResponse = new Employee();     //declaring the fucntion for the record(collection) to Post or add to the Data base...replica(An in Memory)
            
            try
            {                               //To add validation to the record to avoid recreating an already existing account or record using the email as the Unique ID
             var checkRecordExist = employees.Where(e => e.Email == payload.Email).FirstOrDefault();

            if (checkRecordExist != null)
            {
                serviceResponse = new Employee { };

                return serviceResponse;
            }

                {
                    var newRecord = new Employee
                    {
                        EmployeeId = Guid.NewGuid().ToString(), //adds an ID whenever a new record is created using the Post endpoint
                        FirstName = payload.FirstName,
                        LastName = payload.LastName,
                        Email = payload.Email,
                        Password = payload.Password,
                        PhoneNumber = payload.PhoneNumber,
                        Address = payload.Address,
                        CreatedAt = DateTime.Now,
                        LastModifiedAt = DateTime.Now,
                        IsActive = true
                    };
                    employees.Add(newRecord);  //since we're not fetching but posting, use .Add and parse the newRecord Variable

                    serviceResponse = newRecord;  //returns the newRecord back to the User
                }
            }
            catch (Exception)
            {

                throw;
            }
            return serviceResponse;
        }
            public async Task<dynamic> GetAllRecords()  //implemented Interface for Get Record
              {
            var serviceResponse = new List<Employee>();    //declaring Return Type

            try
            {   

                var result = employees.ToList();   //Declaring record to be Fetched

                if (result.Count>0)     //To Validate the Data or record
                {
                    serviceResponse = result;
                }
                else
                {
                    serviceResponse = new List<Employee>();  //if there is no record, Return Empty of the Account
                }
                
            }
            catch (Exception)
            {

                throw;
            }
            return serviceResponse;
        }

        public async Task<dynamic> GetRecordById(string EmployeeId)
        {
            var serviceResponse = new Employee();     //declaring the fucntion for the record(collection) to Post or add to the Data base...replica(An in Memory)

            try
            {
                var checkRecordExist = employees.Where(e => e.EmployeeId == EmployeeId).FirstOrDefault();  //To get record using the EmployeeId
                if (checkRecordExist == null)  //Check if record does not exist
                {
                    serviceResponse = new Employee { };

                    return serviceResponse; //stops the code from runnning further and returns an output that indicates that record does not exist
                }

                
                serviceResponse = checkRecordExist;  //returns the updated record back to the User

            }
            catch (Exception)
            {

                throw;
            }
            return serviceResponse;
        }

        public async Task<dynamic> UpdateAccountAsync(CreateAccountDTO payload)
        {
            var serviceResponse = new Employee();     //declaring the fucntion for the record(collection) to Post or add to the Data base...replica(An in Memory)

            try
            {
               var checkRecordExist = employees.Where(e=>e.Email==payload.Email).FirstOrDefault();  //to check if record already exist
                if(checkRecordExist == null)  //checks if record does not exist
                {
                    serviceResponse = new Employee { };

                    return serviceResponse;    //returns an output that indicates that record does not exist
                }

                checkRecordExist.FirstName =   payload.FirstName;
                checkRecordExist.LastName =    payload.LastName;
                checkRecordExist.Email =       payload.Email;  
                checkRecordExist.PhoneNumber = payload.PhoneNumber; 
                checkRecordExist.Address =     payload.Address;    

                employees.Add(checkRecordExist);  //update records parameter parsed to the add function

                serviceResponse = checkRecordExist;  //returns the updated record back to the User

            }
            catch (Exception)
            {

                throw;
            }
            return serviceResponse;
        }
       
        public async Task<dynamic> DeleteRecordById(string EmployeeId)   //Implemented interface for Delete record
        {
            var serviceResponse = new Employee();     //declaring the fucntion for the record(collection) to Post or add to the Data base...replica(An in Memory)

            try
            {
                var checkRecordExist = employees.Where(e => e.EmployeeId == EmployeeId).FirstOrDefault();  //To get record using the EmployeeId
                if (checkRecordExist == null)  //check if record does not exist
                {
                    serviceResponse = new Employee { };

                    return serviceResponse;   //returns an output that indicates that record does not exist
                }

                employees.Remove(checkRecordExist); 

                serviceResponse = checkRecordExist;  //returns the updated record back to the User

            }
            catch (Exception)
            {

                throw;
            }
            return serviceResponse;
        }
    }
}
