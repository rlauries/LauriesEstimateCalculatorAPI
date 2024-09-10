using LauriesEC.Fence;
using LauriesEC.Fences.Repositories.Interfaces;
using LauriesEC.Fences.Services.Fences;
using LauriesEC.Fences.Services.Interfaces;
using LauriesEC.Service.Calculator.Interfaces;

using LauriesEC.Fences.Repositories;
using LauriesEC.Gate.Services.Interfaces;

namespace LauriesEC.Service.Calculator
{
    public class PriceByService : IPriceByService
    {
        public IFencesFactory _fencesFactory;
        public ISupplier _materials;
        public IStateTaxRate _taxRate;
        public IGateFactory _gateFactory;
        

        public PriceByService(IFencesFactory fencesFactory, ISupplier supplier, IStateTaxRate stateTaxRate, IGateFactory gateFactory)
        {
            _fencesFactory = fencesFactory;
            _materials = supplier;
            _taxRate = stateTaxRate;
            _gateFactory = gateFactory;
        }
        public PriceByService()
        {
            
        }

        public decimal PriceByFenceWithoutTax(FenceModelFromTheBody viewFence)
        {
            
            decimal subTotal = 0;



            var fence = _fencesFactory.GetFencePaperList(viewFence, _materials);
            var materialList = fence.GetMaterialList();
            foreach (var item in materialList)
            { 
                subTotal += item.Price * item.quantityBySqFeet;

            }
            return subTotal; 
        }
        public IFence GetFencePaperListWithoutTax(FenceModelFromTheBody viewFence)
        {

            return _fencesFactory.GetFencePaperList(viewFence, _materials); 
        }


        public decimal PricePerStandarGate()
        {
            decimal subTotal = 0;
            var gateList = _gateFactory.PrintPaperList().GetMaterialList();
            foreach(var item in gateList)
            {
                subTotal += PriceQuantityWithMaterialId(item.Key, item.Value);
            }
            return subTotal + 100;
        }





        public decimal TaxRateByStateName(string stateName)
        {
            var taxRate = _taxRate.GetTaxRateByStateName(stateName);
            
            return taxRate;
        }
        public List<string> GetStateShortener(string stateShortName)
        {
            var nameList = _taxRate.GetStateShortener(stateShortName);
            return nameList;
        }

        public decimal PriceQuantityWithMaterialId(int idProduct, int quantity)
        {
            var price = _materials.GetMaterialById(idProduct).Price;
            return quantity * price;
            
        }
        public Invoice MyInvoice(FenceModelFromTheBody viewFence, string stateName, Invoice invoice)
        {

            //invoice.FenceCard = _fencesServices.PrintFenceCard(viewFence);
            //invoice.PriceWithoutTax = PriceByServiceWithoutTax(viewFence);   
            //invoice.TaxRate = invoice.PriceWithoutTax * TaxRateByStateName(stateName) / 100;
            //invoice.Total = invoice.PriceWithoutTax + invoice.TaxRate;
            return invoice;
        }

    }
}
