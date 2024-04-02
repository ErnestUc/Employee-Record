using employeeRecord.DTOs;
using employeeRecord.Models;
using employeeRecord.Responsess;

namespace employeeRecord.Interface
{
    public interface IAccountService
    {
        Task<ServiceResponse<Employee>> CreateAccountAsync(CreateAccountDTO payload); //interface for the Post Method, parses the fucntion and the Payload(Employee data or Property)
        Task<ServiceResponse<dynamic>> GetAllRecords();                           //Interface for the Get Method
        Task<ServiceResponse<Employee>> GetRecordById(string EmployeeId);           //interface for GetRecordBYID
        Task<ServiceResponse<Employee>> UpdateAccountAsync(CreateAccountDTO payload); //Interface for the Update method   Task<dynamic> UpdateAccountAsync(CreateAccountDTO payload);
        Task<ServiceResponse<Employee>> DeleteRecordById(string EmployeeId);          //Iterface for the Delete Method

    }
}
