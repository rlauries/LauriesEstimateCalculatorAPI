using LauriesEC.Fences.Services.Fences;
using LauriesEC.Fences.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauriesEC.Service.Calculator.Interfaces
{
    public interface IPriceByService
    {
        decimal PriceByFenceWithoutTax(FenceModelFromTheBody viewFence);
        IFence GetFencePaperListWithoutTax(FenceModelFromTheBody viewFence);
        decimal TaxRateByStateName(string stateName);
        List<string> GetStateShortener(string stateShortName);
        Invoice MyInvoice(FenceModelFromTheBody viewFence, 
                                string stateName, Invoice invoice);
        decimal PricePerStandarGate();
    }
}
