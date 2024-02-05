using LauriesEC.Fences.Repositories.Interfaces;
using LauriesEC.Fences.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LauriesEC.Fence.Controller
{
    [Route("api/materials")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        ISupplier materialSupplier;

        public MaterialController(ISupplier supplier)
        {
            materialSupplier = supplier;
        }

        [HttpGet("{id}")]
        public ActionResult<int> GetSqFeet(int id)
        {
            return Ok(materialSupplier.GetMaterialPriceById(id));
        }
    }
}
