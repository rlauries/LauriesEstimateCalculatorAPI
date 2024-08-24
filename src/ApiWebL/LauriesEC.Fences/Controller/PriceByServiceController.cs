
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

        [HttpPost("PanelPrice")]
        public ActionResult<decimal> GetPriceByService([FromBody] FenceModelFromTheBody viewFence)
        {
            var totalPrice = _priceByService.PriceByServiceWithoutTax(viewFence);

            return Ok(totalPrice);
        }
        [HttpGet("GetStateTaxRate/{stateName}")]
        public ActionResult<decimal> GetStateTaxRate(string stateName)
        {
            var taxRate = _priceByService.TaxRateByStateName(stateName);
            return Ok(taxRate);
        }
        [HttpGet("GetStateByShortener/{stateShortName}")]
        public ActionResult<List<string>> GetStateShortener(string stateShortName)
        {
            var nameList = _priceByService.GetStateShortener(stateShortName);
            return Ok(nameList);
        }

        [HttpPost("Invoice")]
        public ActionResult<InvoiceModel> GetInvoice([FromBody] FenceModelFromTheBody viewFence, string stateName)
        { 
            InvoiceModel invoice = new InvoiceModel();
            invoice = _priceByService.MyInvoice(viewFence, stateName, invoice);
            return Ok(invoice);
        }
    }
}
