
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
        public Dictionary<int, int> GetMaterialList() 
        {
            MaterialList = new Dictionary<int, int>()
            {
                {1, (SqFeet / 4 + 1) },
                {2, (SqFeet * NumberHorizontalTubes / 21 + 1)},
                {3, (SqFeet * 12 / 5 + 1)},
                {4, (SqFeet / 4 + 1)}
            };
            return MaterialList;
        }
    }
}
