
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
        public int PostQty { get; set; }
        public int PostId { get; set; } = 1;
        public int TopRailQty { get; set; }
        public int TopRailId { get; set; } = 9;
        public int MayaQty { get; set; }
        public int MayaId { get; set; } = 7;
        public int EyesTopQty { get; set; }
        public int EyesTopId { get; set; } = 10;

        public ChainLink(int sqFeet)
        {
            SqFeet = sqFeet;
            Load();
        }
        public ChainLink()
        {
            
        }
        
        public void Load()
        {

            PostQty = (SqFeet / 4 + 1);
            
            TopRailQty = (SqFeet / 21 + 1);

            MayaQty = (SqFeet / 50 + 1);
            
            EyesTopQty = (SqFeet / 4 + 1);
           
        }
        

    }
}
