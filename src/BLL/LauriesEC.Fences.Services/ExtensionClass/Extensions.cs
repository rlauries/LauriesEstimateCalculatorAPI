
using LauriesEC.Fences.Services.Fences;
using LauriesEC.Fences.Services.Interfaces;

namespace LauriesEC.Fence.ExtensionClass
{
    public static class ExtendFenceCard
    {
        public static IFence PrintFenceCard(this IFencesFactory _fencesServices, FenceModelFromTheBody viewFence)
        {
            if (viewFence.TypeOfFence == FenceType.ChainLink)
            {
                _fencesServices = new FencesFactory(viewFence.SqFeet);
            }
            else if (viewFence.TypeOfFence == FenceType.DuraFence)
            {
                _fencesServices = new FencesFactory(viewFence.SqFeet, viewFence.HorizontalTubes);
            }
            else
            {
                _fencesServices = new FencesFactory(viewFence.SqFeet, viewFence.TubeWidth, viewFence.Gap);
            }
            
            return _fencesServices.GetFencePaperList();

        }
    }
}
