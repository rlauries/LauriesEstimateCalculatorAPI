using LauriesEC.Fences.Services.Interfaces;
using LauriesEC.Fences.Services.Fences;


using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using LauriesEC.Fence.Models;
using LauriesEC.Fence.ExtensionClass;

namespace LauriesEC.Fence.Controller
{
    [ApiController]
    [Route("api/fence")]
    public class FenceController : ControllerBase
    {
        public IFencesServices _fencesServices;
        

        public FenceController(IFencesServices fence) 
        {
            _fencesServices = fence;
        }

       

        [HttpPost("paperList")]
        public ActionResult<IFence> GetFencesPaperListInController([FromBody] FenceModelFromTheBody viewFence)
        {
               var f = _fencesServices.PrintFenceCard(viewFence);

            return Ok(f);
        }

       


    }
}
