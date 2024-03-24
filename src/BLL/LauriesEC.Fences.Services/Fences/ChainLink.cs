
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
        public int SqFeet { get; set; }
        
        public Dictionary<int, int> MaterialList { get; set; }

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
            MaterialList = new Dictionary<int, int>()
            {
                {1, (SqFeet / 4 + 1) },
                {9, (SqFeet / 21 + 1)},
                {7, (SqFeet / 50 + 1)},
                {10, (SqFeet / 4 + 1)}
            };
            return MaterialList;
        }
        

    }
}
