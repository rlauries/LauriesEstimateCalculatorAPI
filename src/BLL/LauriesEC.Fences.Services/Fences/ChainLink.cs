
using LauriesEC.Fences.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauriesEC.Fences.Services.Fences
{
    public  class ChainLink :  IFences
    {
        public int SqFeet { get; set; }
        public int PostQty { get; set; }
        public int PostId = 1;
        public int TopRailQty { get; set; }
        public int TopRailId = 9;
        public int MayaQty { get; set; }
        public int MayaId = 7;
        public int EyesTopQty { get; set; }
        public int EyesTopId = 10 ;

        public ChainLink(int sqFeet)
        {
            SqFeet = sqFeet;
            Load();
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
