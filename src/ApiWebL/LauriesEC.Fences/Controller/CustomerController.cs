using LauriesEC.Fences.Repositories.DatabaseContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Security.Models;

namespace LauriesEC.Fence.Controller
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        LauriesContext _customerContext;
        public CustomerController()
        {
            _customerContext = new LauriesContext();
        }

        [HttpPost("GetCustomerByEmail")]
        public ActionResult<CustomerModel> GetCustomerByEmail([FromBody] string email) 
        {
            var customer = _customerContext.GetCustomerByEmail(email);
            return Ok(customer);
        }

        [HttpPost("processCustomer")]
        public ActionResult<CustomerModel> ProcessMaterial(CustomerModelFromBody modelFromBody)
        {
            CustomerModel customer = _customerContext.ProcessCustomer(
                modelFromBody.Id,
                modelFromBody.Name,
                modelFromBody.LastName,
                modelFromBody.Email,
                modelFromBody.PhoneNumber,
                modelFromBody.Address,
                modelFromBody.City,
                modelFromBody.State,
                modelFromBody.ZipCode);
            return Ok(customer);
        }
    }
}
