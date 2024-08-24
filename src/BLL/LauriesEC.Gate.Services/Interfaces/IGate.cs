using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauriesEC.Gate.Services.Interfaces
{
    public interface IGate
    {
        Dictionary<int, int> GetMaterialList();
    }
}
