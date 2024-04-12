using employeeRecord.Context;
using employeeRecord.DTOs;
using employeeRecord.Interface;
using employeeRecord.Models;
using employeeRecord.Responsess;
using Microsoft.EntityFrameworkCore;
using System.Net;
//using System.Linq.Expressions;

namespace employeeRecord.Services                    
{
    public class AccountService : IAccountService      //The main class that interacts with the data base Where you implement the Interface
    {                                                         //Now we fetch data from the data base and not from the static data
        private readonly AppdataBaseContext _appdataBaseContext;                                                  //injest Dbcontext into account service
        
    public AccountService(AppdataBaseContext  appdataBaseContext)
        {
            _appdataBaseContext = appdataBaseContext; 
        }

        public async Task<ServiceResponse<Employee>> CreateAccountAsync(CreateAccountDTO payload)  //implemented interface for Post record
        {
            var serviceResponse = new ServiceResponse<Employee>();     //declaring the fucntion for the record(collection) to Post or add to the Data base...replica(An in Memory)
            
            try
            {                               //To add validation to the record to avoid recreating an already existing account or record using the email as the Unique ID
             var checkRecordExist = await _appdataBaseContext.EmployeesR.Where(e => e.Email == payload.Email).FirstOrDefaultAsync();

            if (checkRecordExist != null)  //checks if the record is not empty ie record exist.
            {
                serviceResponse.Data = new Employee { };
                    serviceResponse.Message = "Employee Record Already Exist";
                    serviceResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    serviceResponse.Success = false; 

                return serviceResponse;
            }

                {
                    var newRecord = new Employee
                    {
                        EmployeeId = Guid.NewGuid().ToString(), //adds an ID whenever a new record is created using the Post endpoint
                        FirstName = payload.FirstName,
                        LastName = payload.LastName,
                        Email = payload.Email,
                        PhoneNumber = payload.PhoneNumber,
                        Address = payload.Address,
                        CreatedAt = DateTime.Now,
                        LastModifiedAt = DateTime.Now,
                        IsActive = true
                    };
                    _appdataBaseContext.EmployeesR.Add(newRecord);  //since we're not fetching but posting, use .Add and parse the newRecord Variable
                    _appdataBaseContext.SaveChanges();

                    serviceResponse.Data = newRecord;  //returns the newRecord back to the User
                    serviceResponse.StatusCode = (int)HttpStatusCode.Created;
                    serviceResponse.Message = "Record Successfully Created";
                    serviceResponse.Success = true; 
                }
            }
            catch (Exception)
            {

                throw;
            }
            return serviceResponse;
        }
            public async Task<ServiceResponse<dynamic>> GetAllRecords()  //implemented Interface for Get Record   ServiceResponse is specified to accept the generic type and pass in the list of employee
              {                        
            var serviceResponse = new ServiceResponse <dynamic>();    //declaring Return Type, now wrapped into ServiceResponse class

            try
            {   

                var result = _appdataBaseContext.EmployeesR.ToList();   //Declaring record to be Fetched

                if (result.Count>0)     //To Validate the Data or record
                {
                    serviceResponse.Data = result;

                    serviceResponse.StatusCode = 200;  //or use StatusCode = (int)HttpStatusCode.ok; if you don't know the success status code
                    serviceResponse.Message = "Record found";
                    serviceResponse.Success = true; 
                    return serviceResponse;
                }
                else
                {
                    serviceResponse.Data = new List<Employee>();  //if there is no record, Return Empty of the Account
                    serviceResponse.Message = "Record Not Found";
                    serviceResponse.StatusCode = (int)HttpStatusCode.NotFound;
                }
                
            }
            catch (Exception)
            {

                throw;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Employee>> GetRecordById(string EmployeeId)
        {
            var serviceResponse = new ServiceResponse <Employee>();     //declaring the fucntion for the record(collection) to Post or add to the Data base...replica(An in Memory)

            try
            {
                var checkRecordExist = await _appdataBaseContext.EmployeesR.Where(e => e.EmployeeId == EmployeeId).FirstOrDefaultAsync();  //To get record using the EmployeeId
                if (checkRecordExist == null)  //Check if record does not exist
                {
                    serviceResponse.Data = new Employee { };
                    serviceResponse.StatusCode = (int)HttpStatusCode.NotFound;
                    serviceResponse.Message = "Employee Reocrd Does Not Exist";
                    serviceResponse.Success = false;


                    return serviceResponse; //stops the code from runnning further and returns an output that indicates that record does not exist
                }

                
                serviceResponse.Data = checkRecordExist;  //returns the updated record back to the User
                serviceResponse.StatusCode = (int)HttpStatusCode.OK;
                serviceResponse.Message = "Employee Record Found";
                serviceResponse.Success= true;

            }
            catch (Exception)
            {

                throw;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Employee>> UpdateAccountAsync(CreateAccountDTO payload)  //note that in returning dynamic, the type of error the code is likely to return is only determined when the code is run unlike when the return type is specified where the error is seen before the code is run
        {
            var serviceResponse = new ServiceResponse<Employee>();     //declaring the function for the record(collection) to Post or add to the Data base...replica(An in Memory)

            try
            {
               var checkRecordExist = await _appdataBaseContext.EmployeesR.Where(e=>e.Email==payload.Email).FirstOrDefaultAsync();  //to check if record already exist
                if(checkRecordExist == null)  //checks if record does not exist
                {
                    serviceResponse.Data = new Employee { };
                    serviceResponse.Message = "Record Does not Exist";
                    serviceResponse.Success = false;
                    serviceResponse.StatusCode = (int)HttpStatusCode.MisdirectedRequest;

                    return serviceResponse;    //returns an output that indicates that record does not exist
                }

                checkRecordExist.FirstName =   payload.FirstName;
                checkRecordExist.LastName =    payload.LastName;
                checkRecordExist.Email =       payload.Email;  
                checkRecordExist.PhoneNumber = payload.PhoneNumber; 
                checkRecordExist.Address =     payload.Address;

                _appdataBaseContext.EmployeesR.Update(checkRecordExist);  //update records parameter parsed to the add function
                _appdataBaseContext.SaveChanges();

                serviceResponse.Data = checkRecordExist;  //returns the updated record back to the User
                serviceResponse.Message = "Record Update Successful";
                serviceResponse.Success = true;
                serviceResponse.StatusCode = 200;

            }
            catch (Exception)
            {

                throw;
            }
            return serviceResponse;
        }
       
        public async Task<ServiceResponse<Employee>>DeleteRecordById(string EmployeeId)   //Implemented interface for Delete record
        {
            var serviceResponse = new ServiceResponse <Employee>();     //declaring the fucntion for the record(collection) to Post or add to the Data base...replica(An in Memory)

            try
            {
                var checkRecordExist = await _appdataBaseContext.EmployeesR.Where(e => e.EmployeeId == EmployeeId).FirstOrDefaultAsync();  //To get record using the EmployeeId
                if (checkRecordExist == null)  //check if record does not exist
                {
                    serviceResponse.Data = new Employee { };
                    serviceResponse.StatusCode = (int)HttpStatusCode.NotFound;
                    serviceResponse.Message = "Record Does Not Exist";
                    serviceResponse.Success = false;

                    return serviceResponse;   //returns an output that indicates that record does not exist
                }

                _appdataBaseContext.EmployeesR .Remove(checkRecordExist);
                _appdataBaseContext.SaveChanges();  

                serviceResponse.Data = checkRecordExist;  //returns the updated record back to the User
                serviceResponse.Message = "Record Successfully Deleted";
                serviceResponse.Success = true;
                serviceResponse.StatusCode = 200;

            }
            catch (Exception)
            {

                throw;
            }
            return serviceResponse;
        }
    }
}
