using LauriesEC.Fences.Repositories.DatabaseContext;
using LauriesEC.Fences.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauriesEC.Fences.Repositories
{
    public class USATaxRate : IStateTaxRate
    {
        public LauriesContext context { get; set; }
        public USATaxRate()
        {
            context = new LauriesContext();
        }
        public USATaxRate(LauriesContext context)
        {
            this.context = context;
        }
        public decimal GetTaxRateByStateName(string stateName)
        {
            return context.GetTaxRateByStateName(stateName);
        }
        public List<string> GetStateShortener(string stateShortName)
        {
            return context.GetStateShortener(stateShortName);
        }
    }
}
