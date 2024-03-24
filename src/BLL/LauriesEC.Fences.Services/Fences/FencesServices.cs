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
    public class FencesServices : IFencesServices
    {
        public IFence fence { get; set; }
       


        public FencesServices() { }
        
        public FencesServices(int sqFeet)
        {
            fence = new ChainLink(sqFeet);
        }

        public FencesServices(int sqFeet, int horizontalTubing)
        {
            fence = new DuraFence(sqFeet, horizontalTubing);
        }
        public FencesServices(int sqFeet, int tubeWide, int gap)
        {
            fence = new AluminumCustom(sqFeet, tubeWide, gap); 
            
        }
        
        
        public IFence GetFencePaperList()
        {

            return fence;

        }

        

    }
}
