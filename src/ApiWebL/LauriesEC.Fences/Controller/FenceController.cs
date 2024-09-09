using LauriesEC.Fences.Services.Interfaces;
using LauriesEC.Fences.Services.Fences;


using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using LauriesEC.Fence.Models;

using LauriesEC.Fences.Repositories.DatabaseContext;
using LauriesEC.Fences.Repositories.DataModels;
using LauriesEC.Fences.Repositories.Interfaces;
using LauriesEC.Fences.Repositories;


namespace LauriesEC.Fence.Controller
{
    [ApiController]
    [Route("api/fence")]
    public class FenceController : ControllerBase
    {
        public IFencesFactory _fencesServices;
        public LauriesContext _lauriesContext;
        public ISupplier _supplier;

        public FenceController(IFencesFactory fence, ISupplier supplier) 
        {
            _fencesServices = fence;
            _lauriesContext = new LauriesContext();
            _supplier = supplier;
        }

       

        [HttpPost("paperList")]
        public ActionResult<IFence> GetFencesPaperListInController([FromBody] FenceModelFromTheBody viewFence)
        {
               var f = _fencesServices.GetFencePaperList(viewFence, _supplier);

            return Ok(f);
        }
        [HttpGet("fenceList")]
        public ActionResult<List<FenceModel>> GetFenceTypeList()
        {
            return Ok(_lauriesContext.GetFenceListFromDB());
        }
       


    }
}
