
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
        public int PostQty { get; set; }
        public int PostId { get; set; } = 1;

        public int NumberHorizontalTubes { get; set; }  // 2 or 3 horizontal designs
        public int HorizontalTubesQty {  get; set; }
        public int HorizontalTubeId { get; set; } = 2;
        public int ArrowQty { get; set; }
        public int ArrowId { get; set; } = 3;  
        public int PlasticCap {  get; set; }
        public int PlasticCapId { get; set; } = 4;

        public DuraFence(int sqFeet, int horizontalTubes)
        {
            SqFeet = sqFeet;
            NumberHorizontalTubes = horizontalTubes;
            Load();
        }
        public DuraFence()
        {
            
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
