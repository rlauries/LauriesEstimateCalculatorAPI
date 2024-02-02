
using LauriesEC.Fences.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauriesEC.Fences.Services.Fences
{
    public class AluminumCustom : IFences  
    {
        public int SqFeet { get; set; }
        public int PostQty { get; set; }

        public int TubeWidth { get; set; }
        public int TubeWidthId = 0;
        public int Gap {  get; set; }
        public int HorizontalTubeQty { get; set; }   


        public AluminumCustom(int sqFeet, int tubeWidth, int gap)
        {
            TubeWidthId = (tubeWidth == 4) 
                ? (TubeWidthId = 12) 
                : (TubeWidthId = 13);
            SqFeet = sqFeet;
            TubeWidth = tubeWidth;
            Gap = gap;
        }
        public void Load()
        {
            PostQty = (SqFeet / 4 + 1);
            HorizontalTubeQty = (SqFeet/24) * (68 / (TubeWidth + Gap) + 1);
        }
    }
}
