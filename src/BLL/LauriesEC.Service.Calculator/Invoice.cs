using LauriesEC.Fences.Services.Fences;
using LauriesEC.Fences.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauriesEC.Service.Calculator
{
    public class InvoiceModel
    {
        public IFence FenceCard { get; set; }
        public decimal PriceWithoutTax {  get; set; }
        public decimal TaxRate { get; set; }


        public InvoiceModel()
        {
            
        }

    }
}
