using LauriesEC.Fence.Models;
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

        [HttpGet("showWholeMatrialList")]
        public ActionResult<List<MaterialsModel>> ShowMaterialList()
        {
            return Ok(materialSupplier.ShowMaterialList());
        }

        [HttpGet("getMaterialById/{id}")]
        public ActionResult<MaterialsModel> GetMaterialById(int id)
        {
            return Ok(materialSupplier.GetMaterialById(id));
        }


        [HttpPost("processMaterials")]
        public ActionResult UpdateMaterialPrice(MaterialModelFromBody materialFromBody)
        {
            MaterialsModel material = materialSupplier.UpdateMaterialPriceById(
                    materialFromBody.Id,
                    materialFromBody.Name,
                    materialFromBody.Price, 
                    materialFromBody.MaterialType);
            return Ok(material);
        }
    }
}
