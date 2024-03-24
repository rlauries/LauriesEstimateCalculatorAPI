using LauriesEC.Fence;
using LauriesEC.Fences.Services.Fences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauriesEC.Fences.Services.Interfaces
{
    public interface IFencesServices
    {
        //int GetSqFeet();
        IFence GetFencePaperList();
        
    }
}
