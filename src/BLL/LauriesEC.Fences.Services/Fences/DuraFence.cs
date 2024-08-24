
using LauriesEC.Fences.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauriesEC.Fences.Services.Fences
{
    public class DuraFence : IFence
    {
        const int T2x2 = 1;
        const int T2X1 = 2;
        const int Arrow = 3;
        const int PlasticCap = 4;
        public int SqFeet { get; set; }
        public int NumberHorizontalTubes { get; set; }  // 2 or 3 horizontal designs
       
        public Dictionary<int, int> MaterialList { get; set; }

        public DuraFence(int sqFeet, int horizontalTubes)
        {
            SqFeet = sqFeet;
            NumberHorizontalTubes = horizontalTubes;
            GetMaterialList();
        }
        public DuraFence()
        {
            
        }

        //this dictionary contain Material Type and the quatity base on sqFeet
        public Dictionary<int, int> GetMaterialList() 
        {
            if (SqFeet == 0)
            {
                return new Dictionary<int, int>();
            }
            MaterialList = new Dictionary<int, int>()
            {
                {T2x2, (SqFeet / 4 + 1) },
                {T2X1, (SqFeet * NumberHorizontalTubes / 21 + 1)},
                {Arrow, (SqFeet * 12 / 5 + 1)},
                {PlasticCap, (SqFeet / 4 + 1)}
            };
            return MaterialList;
        }
    }
}
