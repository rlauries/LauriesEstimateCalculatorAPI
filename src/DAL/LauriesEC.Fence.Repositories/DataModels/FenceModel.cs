using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauriesEC.Fences.Repositories.DataModels
{
    public enum FenceType //FenceType
    {
        ChainLink = 1,
        DuraFence = 2,
        AluminioCustom = 3,
    }

    public class FenceModel
    {
       
        public int ID { get; set; }
        public string? Name { get; set; }
        public int SqFeet { get; set; }
        public string? NameId { get; set; }
        public string? Size { get; set; }
        public string? Installation { get; set; }


        
    }
}
