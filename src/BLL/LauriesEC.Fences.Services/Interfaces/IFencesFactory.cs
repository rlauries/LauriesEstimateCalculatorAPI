using LauriesEC.Fence;
using LauriesEC.Fences.Repositories.Interfaces;
using LauriesEC.Fences.Services.Fences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauriesEC.Fences.Services.Interfaces
{
    public interface IFencesFactory
    {
        //int GetSqFeet();

        IFence GetFencePaperList(FenceModelFromTheBody viewFence, ISupplier supplier);


    }
}
