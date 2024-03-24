
using LauriesEC.Fence.Models;
using LauriesEC.Fences.Services.Fences;
using LauriesEC.Fences.Services.Interfaces;
using LauriesEC.Service.Calculator;
using LauriesEC.Service.Calculator.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LauriesEC.Fence.Controller
{
    [Route("api/price")]
    [ApiController]
    public class PriceByServiceController : ControllerBase
    {

        IPriceByService _priceByService;

        public PriceByServiceController(IPriceByService priceByServices)
        {
            _priceByService = priceByServices;
        }

        [HttpPost("PriceByService")]
        public ActionResult<decimal> GetPriceByService([FromBody] FenceModelFromTheBody viewFence)
        {
            var totalPrice = _priceByService.PriceByServiceWithoutTax(viewFence);

            return Ok(totalPrice);
        }

        [HttpPost("Invoice")]
        public ActionResult<InvoiceModel> GetInvoice([FromBody] FenceModelFromTheBody viewFence)
        { 
            InvoiceModel invoice = new InvoiceModel();
            invoice = _priceByService.MyInvoice(viewFence, invoice);
            return Ok(invoice);
        }
    }
}
