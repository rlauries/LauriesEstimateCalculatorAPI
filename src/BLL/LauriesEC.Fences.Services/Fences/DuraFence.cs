
using LauriesEC.Fences.Repositories.DataModels;
using LauriesEC.Fences.Repositories.Interfaces;
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
        const int T2x2 = 1;
        const int T2X1 = 2;
        const int Arrow = 3;
        const int PlasticCap = 4;
        public int SqFeet { get; set; }
        public int NumberHorizontalTubes { get; set; }  // 2 or 3 horizontal designs

        public List<MaterialsModel> MaterialList { get; set; } = new List<MaterialsModel>();
        ISupplier supplier;
        public DuraFence(int sqFeet, int horizontalTubes,ISupplier supplier)
        {
            SqFeet = sqFeet;
            NumberHorizontalTubes = horizontalTubes;
            this.supplier = supplier;
            SetMaterialList();
        }
        public DuraFence()
        {
            
        }
        public List<MaterialsModel> GetMaterialList()
        {
            return MaterialList;
        }
        //this dictionary contain Material Type and the quatity base on sqFeet
        public void SetMaterialList() 
        {
            
            
            MaterialList.Add(supplier.GetMaterialById(T2x2));
            MaterialList[0].quantityBySqFeet = (SqFeet / 4 + 1);
            MaterialList.Add(supplier.GetMaterialById(T2X1));
            MaterialList[1].quantityBySqFeet = (SqFeet * NumberHorizontalTubes / 21 + 1);
            MaterialList.Add(supplier.GetMaterialById(Arrow));
            MaterialList[2].quantityBySqFeet = (SqFeet * 12 / 5 + 1); //the formula conver from sqfeet to inces
            MaterialList.Add(supplier.GetMaterialById(PlasticCap));
            MaterialList[3].quantityBySqFeet = (SqFeet / 4 + 1);

            


        }
    }
}
