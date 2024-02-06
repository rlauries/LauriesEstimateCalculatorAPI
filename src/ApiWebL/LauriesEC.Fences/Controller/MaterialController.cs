using LauriesEC.Fences.Repositories;
using LauriesEC.Fences.Repositories.DataModels;
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
        public ActionResult<MaterialsModel> GetMaterialById(MaterialsName id)
        {
         //validatio for Id null Bad request
            return Ok(materialSupplier.GetMaterialById(id));
        }
        //[HttpPost("{price}")]
        //public ActionResult UpdateMaterialPrice(decimal price)
        //{

        //}
    }
}
