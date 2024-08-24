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
        public IFence fence { get; set; }
       


        public FencesFactory() { }
        
        public FencesFactory(int sqFeet)
        {
            fence = new ChainLink(sqFeet);
        }

        public FencesFactory(int sqFeet, int horizontalTubing)
        {
            fence = new DuraFence(sqFeet, horizontalTubing);
        }
        public FencesFactory(int sqFeet, int tubeWide, int gap)
        {
            fence = new AluminumCustom(sqFeet, tubeWide, gap); 
            
        }
        
        
        public IFence GetFencePaperList()
        {

            return fence;

        }

        

    }
}
