using LauriesEC.Fences.Services;
using LauriesEC.Fences.Repositories;
using LauriesEC.Fences.Repositories.Interfaces;
using LauriesEC.Fences.Services.Fences;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc.ViewFeatures;


namespace LauriesEC.Fence
{
    public enum FenceType //FenceType
    {
        ChainLink = 1,
        DuraFence = 2,
        AluminioCustom = 3,
    }
    public class FencesPriceCalculator
    {
        public int SqFeet {  get; set; }
        public int HorizontalTubes { get; set; }
        public int TubeWidth { get; set; }
        public int Gap {  get; set; }

        Dictionary<FenceType, IFences> Fence; 

        public FencesPriceCalculator(int sqFeet, int horizontalTubes, int tubeWidth, int gap)
        {
            SqFeet = sqFeet;
            HorizontalTubes = horizontalTubes;
            TubeWidth = tubeWidth;
            Gap = gap;
            Load();

        }
        public void Load()
        {
            Fence = new Dictionary<FenceType, IFences>()
            {
                {FenceType.ChainLink, new ChainLink(SqFeet) },
                {FenceType.DuraFence,new DuraFence(SqFeet, HorizontalTubes) },
                {FenceType.AluminioCustom, new AluminumCustom(SqFeet, TubeWidth, Gap) } 

            };
        }



    }
}
