using LauriesEC.Fences.Repositories.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauriesEC.Fences.Services.Interfaces
{
    public interface IFence
    {
        List<MaterialsModel> GetMaterialList();
    }

   
}
