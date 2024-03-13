using employeeRecord.DTOs;

namespace employeeRecord.Interface
{
    public interface IAccountService
    {
        Task<dynamic> CreateAccountAsync(CreateAccountDTO payload); //interface for the Post Method, parses the fucntion and the Payload(Employee data or Property)
        Task<dynamic> GetAllRecords();                              //Interface for the Get Method
        Task<dynamic> GetRecordById(String EmployeeId);             //interface for GetRecordBYID
        Task<dynamic> UpdateAccountAsync(CreateAccountDTO payload); //Interface for the Update method
        Task<dynamic> DeleteRecordById(string EmployeeId);           //Iterface for the Delete Method

    }
}
