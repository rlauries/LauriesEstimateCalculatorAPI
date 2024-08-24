
using LauriesEC.Fences.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauriesEC.Fences.Services.Fences
{ 
    public  class ChainLink : IFence
    {
        const int T2x2 = 1;
        const int TopRail3_8 = 9;
        const int Maya = 7;
        const int EyesTop = 10;
        public int SqFeet { get; set; } = 0;

        public Dictionary<int, int> MaterialList { get; set; } = null;

        public ChainLink(int sqFeet)
        {
            SqFeet = sqFeet;
            GetMaterialList();
        }
        public ChainLink()
        {
            
        }

    

        public Dictionary<int,int> GetMaterialList()
        {
            if (SqFeet == 0) {
                return new Dictionary<int, int>();
            } 

            //this dictionary contain Material Type and the quatity base on sqFeet
            MaterialList = new Dictionary<int, int>()
            {
                {T2x2, (SqFeet / 4 + 1) },
                {TopRail3_8, (SqFeet / 21 + 1)},
                {Maya, (SqFeet / 50 + 1)},
                {EyesTop, (SqFeet / 4 + 1)}
            };
            return MaterialList;
        }
        

    }
}
