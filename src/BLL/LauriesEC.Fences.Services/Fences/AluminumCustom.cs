
using LauriesEC.Fences.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauriesEC.Fences.Services.Fences
{
    public class AluminumCustom : IFence
    {
        public int SqFeet { get; set; }
        public int PostQty { get; set; }
        public int PostId { get; set; } = 14;

        public int TubeWidth { get; set; }
        public int TubeWidthId { get; set; } = 0;
        public int Gap {  get; set; }

        public int HorizontalTubeQty { get; set; }
        public Dictionary<int, int> MaterialList { get; set; }


        public AluminumCustom(int sqFeet, int tubeWidth, int gap)
        {
            TubeWidthId = (tubeWidth == 4) 
                ? (TubeWidthId = 12) 
                : (TubeWidthId = 13);
            SqFeet = sqFeet;
            TubeWidth = tubeWidth;
            Gap = gap;
            GetMaterialList();
        }
        public Dictionary<int, int> GetMaterialList()
        {
            MaterialList = new Dictionary<int, int>()
            {
                {14, (SqFeet / 4 + 1) },
                {TubeWidthId, (SqFeet/24) * (68 / (TubeWidth + Gap) + 1) }
            };
            return MaterialList; 
        }
    }
}
