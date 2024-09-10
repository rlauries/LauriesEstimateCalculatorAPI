
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
    public class AluminumCustom : IFence
    {
        
        const int SqPost4x1 = 12;
        const int SqPost2x1 = 13;
        const int SqPost2x2 = 14;

        public int SqFeet { get; set; } = 0;
        public int TubeWidth { get; set; } = 0;
        public int TubeWidthId { get; set; } = 0;
        public int Gap { get; set; } = 0;

        public int HorizontalTubeQty { get; set; }
        public List<MaterialsModel> MaterialList { get; set; } = new List<MaterialsModel>();
        ISupplier supplier;

        public AluminumCustom(int sqFeet, int tubeWidth, int gap, ISupplier supplier)
        {
            TubeWidthId = (tubeWidth == 4) 
                ? (TubeWidthId = SqPost4x1) 
                : (TubeWidthId = SqPost2x1);
            this.SqFeet = sqFeet;
            this.TubeWidth = tubeWidth;
            this.Gap = gap;
            this.supplier = supplier;   
            SetMaterialList();
        }

        //this dictionary contain Material Type and the quatity base on sqFeet
        public void SetMaterialList()
        {
            MaterialList.Add(supplier.GetMaterialById(SqPost2x2));
            MaterialList[0].quantityBySqFeet = (SqFeet / 4 + 1);
            MaterialList.Add(supplier.GetMaterialById(TubeWidthId));
            MaterialList[1].quantityBySqFeet = (SqFeet / 24) * (68 / (TubeWidth + Gap) + 1);

        }
        public List<MaterialsModel> GetMaterialList()
        {
            return MaterialList;
        }
    }
}
