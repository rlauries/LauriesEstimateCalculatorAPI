using LauriesEC.Fences.Services.Interfaces;
using LauriesEC.Fences.Services.Fences;


using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using LauriesEC.Fence.FenceModelFromTheBody;

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

     

        [HttpPost()]
        public ActionResult<IFence> GetFenceByTypoOfFence([FromBody] FenceModelFromBody viewFence)
        {
           

            _fencesServices = new FencesServices(viewFence.SqFeet, viewFence.HorizontalTubes, viewFence.TubeWidth, viewFence.Gap);
            IFence fenceFromDataBase = _fencesServices.GetFenceByFenceType(viewFence.TypeOfFence);


            return Ok(fenceFromDataBase);

        }


    }
}
