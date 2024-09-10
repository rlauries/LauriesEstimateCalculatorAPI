using LauriesEC.Fences.Repositories.Interfaces;
using LauriesEC.Fences.Services;
using LauriesEC.Fences.Services.Fences;
using LauriesEC.Fences.Services.Interfaces;



namespace LauriesEC.Fence
{
    public enum FenceType  //FenceType 
    {
        ChainLink = 1,
        DuraFence = 2,
        AluminioCustom = 3,
    }
    public class FencesFactory : IFencesFactory
    {
        public IFence Fence { get; set; }
         
       
        public FencesFactory() { }
        
        //public FencesFactory(FenceModelFromTheBody viewFence, ISupplier supplier)
        //{
            

        //   GetFencePaperList(viewFence, supplier);
            
        //}
        public IFence GetFencePaperList(FenceModelFromTheBody viewFence, ISupplier supplier)
        {
            if (viewFence.TypeOfFence == FenceType.ChainLink)
            {
                Fence = new ChainLink(viewFence.SqFeet, supplier);
            }
            else if (viewFence.TypeOfFence == FenceType.DuraFence)
            {
                Fence = new DuraFence(viewFence.SqFeet, viewFence.HorizontalTubes, supplier);
            }
            else if (viewFence.TypeOfFence == FenceType.AluminioCustom)
            {
                Fence = new AluminumCustom(viewFence.SqFeet, viewFence.TubeWidth, viewFence.Gap, supplier);
            }
            var f = Fence;
            return f; 
        }

    }
}
