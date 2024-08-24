using LauriesEC.Gate.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauriesEC.Gate.Services.Interfaces
{
    public interface IGateFactory
    {
         IGate PrintPaperList();
    }
}
