using LauriesEC.Fences.Services.Fences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauriesEC.Service.Calculator.Interfaces
{
    public interface IPriceByService
    {
        decimal PriceByServiceWithoutTax(FenceModelFromTheBody viewFence);
        InvoiceModel MyInvoice(FenceModelFromTheBody viewFence, InvoiceModel invoice);
    }
}
