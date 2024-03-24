using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauriesEC.Fences.Repositories.DataModels
{
    public class StateTaxRate
    {
        public int Id {  get; set; }
        public string StateName {  get; set; }
        public decimal TaxRate { get; set; }
        public string? ResultDescription { get; set; }

    }
}
