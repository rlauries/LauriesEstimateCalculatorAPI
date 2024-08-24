
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
        
        const int SqPost4x1 = 12;
        const int SqPost2x1 = 13;
        const int SqPost2x2 = 14;


        public int TubeWidth { get; set; }
        public int TubeWidthId { get; set; } = 0;
        public int Gap {  get; set; }

        public int HorizontalTubeQty { get; set; }
        public Dictionary<int, int> MaterialList { get; set; } = null;


        public AluminumCustom(int sqFeet, int tubeWidth, int gap)
        {
            TubeWidthId = (tubeWidth == 4) 
                ? (TubeWidthId = SqPost4x1) 
                : (TubeWidthId = SqPost2x1);
            SqFeet = sqFeet;
            TubeWidth = tubeWidth;
            Gap = gap;
            GetMaterialList();
        }

        //this dictionary contain Material Type and the quatity base on sqFeet
        public Dictionary<int, int> GetMaterialList()
        {
            if(SqFeet == 0)
               return new Dictionary<int, int>();
                
            
            MaterialList = new Dictionary<int, int>()
            {
                {SqPost2x2, (SqFeet / 4 + 1) },
                {TubeWidthId, (SqFeet/24) * (68 / (TubeWidth + Gap) + 1) }
            };
            return MaterialList;
            

            
        }
    }
}
