using LauriesEC.Fences.Repositories.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauriesEC.Fences.Repositories.Interfaces
{
    public interface ISupplier
    {
        List<MaterialsModel> ShowMaterialList();
        MaterialsModel GetMaterialById(int materialId); 
        MaterialsModel UpdateMaterialPriceById(int materialsId, string name, decimal price, int materialType);
    }
}
