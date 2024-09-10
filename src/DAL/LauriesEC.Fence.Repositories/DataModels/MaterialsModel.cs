using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauriesEC.Fences.Repositories.DataModels
{
    

    public class MaterialsModel
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        public decimal Price { get; set; }
        public int MaterialType { get; set; }
        public Boolean IsAvailable { get; set; }
        public int quantityBySqFeet = 0;
        public string? ResultDescription { get; set; }
    }
    
}
