using FirstCustomerProject.DTO;
using FirstCustomerProject.NewFolder2;

namespace FirstCustomerProject.NewFolder1
{
    public class AccountServices : IAccountService
       
        {
        public AccountServices()
        {
            
        }
       public async Task<dynamic> RegisterAsync(RegisterDTOs paylaod)
        {
            var serviceResponse = new RegisterDTOs();
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            return serviceResponse;
        }
    }

   
}
