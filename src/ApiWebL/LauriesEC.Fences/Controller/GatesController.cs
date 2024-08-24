using Microsoft.AspNetCore.Mvc;
using LauriesEC.Gate.Services.Models;
using LauriesEC.Gate.Services.Interfaces;
using LauriesEC.Service.Calculator.Interfaces;


namespace LauriesEC.Fence.Controller
{
    [Route("api/Gates")]
    [ApiController]
    public class GatesController : ControllerBase
    {
        public IPriceByService priceByService;

        public GatesController(IPriceByService priceByService)
        {
            this.priceByService = priceByService;
        }

        [HttpGet("StandardDoor/{numberOfDoors}")]
        public ActionResult<decimal> GetGatePaperList(int numberOfDoors)
        {
             return Ok(priceByService.PricePerStandarGate() * numberOfDoors);
        }

    }
}
