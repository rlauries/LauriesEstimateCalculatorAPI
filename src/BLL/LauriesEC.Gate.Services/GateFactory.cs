using LauriesEC.Gate.Services.Interfaces;
using LauriesEC.Gate.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauriesEC.Gate.Services
{
    public class GateFactory : IGateFactory
    {
        public IGate gate { get; set; }
        public GateFactory()
        {
            

        }


        public IGate PrintPaperList()
        {
            gate =  new StandardDoorModel();  
            return gate;
        }
    }
    
}
