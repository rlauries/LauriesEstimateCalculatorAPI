using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauriesEC.Fences.Repositories.Interfaces
{
    public interface IStateTaxRate
    {
        decimal GetTaxRateByStateName(string stateName);
        List<string> GetStateShortener(string stateShortName);
    }
}
