using FirstCustomerProject.DTO;

namespace FirstCustomerProject.NewFolder2
{
    public interface IAccountService
    {
       Task<dynamic> RegisterAsync(RegisterDTOs payload);
    }
}
