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
        //IFence _chainLink;
        //IFence _duraFence;
        //public List<IFence> Fence;

        public Dictionary<FenceType, IFence> Fences { get; set; }

        public FencesServices() { }
        public FencesServices(int sqFeet, int horizontalTubes, int tubeWidth, int gap)
        {
            //_chainLink = new ChainLink(sqFeet);
            //_duraFence = new DuraFence(sqFeet, horizontalTubes);

            //Fence =  new List<IFence>();
            //Fence.Add(_chainLink);
            //Fence.Add(_duraFence);
            Fences = new Dictionary<FenceType, IFence>()
           {
               {FenceType.ChainLink, new ChainLink(sqFeet) },
               {FenceType.DuraFence, new DuraFence(sqFeet,horizontalTubes) },
               {FenceType.AluminioCustom, new AluminumCustom(sqFeet, tubeWidth, gap) },

           };

        }

        public IFence GetFenceByFenceType(FenceType fenceType)
        {

            foreach (var fence in Fences)
            {
                if (fence.Key == fenceType)
                    return fence.Value;

            }
            return null;

        }
        //public int GetSqFeet()
        //{
        //    return chainklink.SqFeet;
        //}


    }
}
