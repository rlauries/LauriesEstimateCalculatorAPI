using LauriesEC.Fences.Repositories.DatabaseContext;
using LauriesEC.Fences.Repositories.DataModels;
using LauriesEC.Fences.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauriesEC.Fences.Repositories
{
    public class Supplier : ISupplier
    {
        public LauriesContext context;
        public Supplier()
        {
            context = new LauriesContext();
        }
      

        public MaterialsModel GetMaterialById(MaterialsName materialsName) 
        {
            MaterialsModel materialFromDataBase = context.GetMaterialById(materialsName); 
            return materialFromDataBase;
        }

        //public MaterialsModel UpdateMaterialPriceById(MaterialsName materialsName, decimal price)
        //{
        //    MaterialsModel materialFromDataBase = context.ProcessMaterials(materialsName);

        //}

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
