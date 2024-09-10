
using LauriesEC.Fences.Repositories.DataModels;
using LauriesEC.Fences.Repositories.Interfaces;
using LauriesEC.Fences.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
        public List<MaterialsModel> MaterialList { get; set; } = new List<MaterialsModel>();
        public ISupplier supplier;

        public ChainLink(int sqFeet, ISupplier supplier)
        {
            SqFeet = sqFeet;
            this.supplier = supplier;
            SetMaterialList();
        }
        public ChainLink()
        {
            
        }

    

        public void SetMaterialList()
        {
            MaterialList.Add(supplier.GetMaterialById(T2x2));
            MaterialList[0].quantityBySqFeet = (SqFeet / 4 + 1);
            MaterialList.Add(supplier.GetMaterialById(TopRail3_8));
            MaterialList[1].quantityBySqFeet = (SqFeet / 21 + 1);
            MaterialList.Add(supplier.GetMaterialById(Maya));
            MaterialList[2].quantityBySqFeet = (SqFeet / 50 + 1);
            MaterialList.Add(supplier.GetMaterialById(EyesTop));
            MaterialList[3].quantityBySqFeet = (SqFeet / 4 + 1);

        }
        public List<MaterialsModel> GetMaterialList()
        {
            return MaterialList;
        }


    }
}
