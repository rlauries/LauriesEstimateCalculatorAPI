
using LauriesEC.Fences.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauriesEC.Fences.Services.Fences
{
    public class DuraFence : IFences
    {
        public int SqFeet { get; set; }
        public int PostQty { get; set; }
        public int PostId = 1;

        public int NumberHorizontalTubes { get; set; }  // 2 or 3 horizontal designs
        public int HorizontalTubesQty {  get; set; }
        public int HorizontalTubeId = 2;
        public int ArrowQty { get; set; }
        public int ArrowId = 3;
        public int PlasticCap {  get; set; }
        public int PlasticCapId = 4;

        public DuraFence(int sqFeet, int horizontalTubes)
        {
            SqFeet = sqFeet;
            NumberHorizontalTubes = horizontalTubes;
            Load();
        }
        public void Load() 
        {
            PostQty = (SqFeet / 4 + 1);
            HorizontalTubesQty = (SqFeet * NumberHorizontalTubes / 21 + 1);
            ArrowQty = (SqFeet * 12 / 5 + 1);
            PlasticCap = (SqFeet / 4 + 1);

        }
    }
}
