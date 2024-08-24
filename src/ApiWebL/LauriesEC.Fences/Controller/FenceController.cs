using LauriesEC.Fences.Services.Interfaces;
using LauriesEC.Fences.Services.Fences;


using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using LauriesEC.Fence.Models;
using LauriesEC.Fence.ExtensionClass;
using LauriesEC.Fences.Repositories.DatabaseContext;
using LauriesEC.Fences.Repositories.DataModels;


namespace LauriesEC.Fence.Controller
{
    [ApiController]
    [Route("api/fence")]
    public class FenceController : ControllerBase
    {
        public IFencesFactory _fencesServices;
        public LauriesContext _lauriesContext;
        

        public FenceController(IFencesFactory fence) 
        {
            _fencesServices = fence;
            _lauriesContext = new LauriesContext();
        }

       

        [HttpPost("paperList")]
        public ActionResult<IFence> GetFencesPaperListInController([FromBody] FenceModelFromTheBody viewFence)
        {
               var f = _fencesServices.PrintFenceCard(viewFence);

            return Ok(f);
        }
        [HttpGet("fenceList")]
        public ActionResult<List<FenceModel>> GetFenceTypeList()
        {
            return Ok(_lauriesContext.GetFenceListFromDB());
        }
       


    }
}
