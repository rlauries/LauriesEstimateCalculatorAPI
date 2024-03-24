using LauriesEC.Fence;
using LauriesEC.Fences.Repositories.Interfaces;
using LauriesEC.Fences.Services.Fences;
using LauriesEC.Fences.Services.Interfaces;
using LauriesEC.Service.Calculator.Interfaces;
using LauriesEC.Fence.ExtensionClass;
using LauriesEC.Fences.Repositories;

namespace LauriesEC.Service.Calculator
{
    public class PriceByService : IPriceByService
    {
        public IFencesServices _fencesServices;
        public ISupplier _materials;
        public IStateTaxRate _taxRate;

        

        public PriceByService(IFencesServices fences, ISupplier supplier, IStateTaxRate stateTaxRate)
        {
            _fencesServices = fences;
            _materials = supplier;
            _taxRate = stateTaxRate;
        }
        public PriceByService()
        {
            
        }

        public decimal PriceByServiceWithoutTax(FenceModelFromTheBody viewFence)
        {
            decimal subTotal = 0;
            var fenceCard = _fencesServices;
            var materialList = fenceCard.PrintFenceCard(viewFence).GetMaterialList();
            foreach (var item in materialList)
            {
                subTotal += PriceQuantityWithMaterialId(item.Key, item.Value);

            }
            return subTotal; 
        }

        public decimal TaxRateByStateName(FenceModelFromTheBody viewFence)
        {
            var taxRate = _taxRate.GetTaxRateByStateName(viewFence.StateName);
            
            return taxRate;
        }


        public decimal PriceQuantityWithMaterialId(int idProduct, int quantity)
        {
            var price = _materials.GetMaterialById(idProduct).Price;
            return quantity * price;
            
        }
        public InvoiceModel MyInvoice(FenceModelFromTheBody viewFence, InvoiceModel invoice)
        {

            invoice.FenceCard = _fencesServices.PrintFenceCard(viewFence);
            invoice.PriceWithoutTax = PriceByServiceWithoutTax(viewFence);   
            invoice.TaxRate = invoice.PriceWithoutTax * TaxRateByStateName(viewFence) / 100;
            invoice.Total = invoice.PriceWithoutTax + invoice.TaxRate;
            return invoice;
        }

    }
}
