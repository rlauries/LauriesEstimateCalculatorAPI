using LauriesEC.Fences.Services.Interfaces;
using LauriesEC.Fences.Services.Fences;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{typeOfFence},{sqFeet},{horizontalTubes},{tubeWidth},{gap}")]
        public ActionResult<IFence> GetFenceByTypoOfFence(FenceType typeOfFence, int sqFeet, int horizontalTubes, int tubeWidth, int gap)
        {
            _fencesServices = new FencesServices(sqFeet,horizontalTubes, tubeWidth, gap);
            IFence f = _fencesServices.GetFenceByFenceType(typeOfFence);
            
            
            return Ok(f);

        }

        //[HttpPost()]
        //public ActionResult<int> GetFenceByTypoOfFence(ModelViewFence modelViewFence)
        //{
        //    _fencesServices = new FencesServices(modelViewFence);
        //    IFence f = _fencesServices.GetFenceByFenceType(typeOfFence);
        //    return Ok(f);
         //}


    }
}
