using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauriesEC.Fences.Repositories.DataModels
{
    

    public class MaterialsModel
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        public decimal Price { get; set; }
        public int MaterialType { get; set; }
        public Boolean IsAvailable { get; set; }

        public string? ResultDescription { get; set; }
    }
    public enum MaterialTypes
    {
        Hierro = 1,
        Aluminio = 2,
        StainlessSteel = 3
    }
    public enum MaterialsName
    {
        Sq2 = 1,
        Rct2x1 = 2,
        Arrow = 3,
        PlasticCap = 4,
        Visagras = 5,
        Latch = 6,
        Maya = 7,
        RailEnd = 8,
        TopRail3_8 = 9,
        EyesTop = 10,
        CornerPost = 11,
        T4x1 = 12,
        T2x1 = 13,
        T2x2 = 14,
        T1x1 = 15,
        T4x2 = 16,
        T3x2 = 17
    }
}
