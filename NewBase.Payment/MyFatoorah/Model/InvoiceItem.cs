using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBase.Payment.MyFatoorah.Model
{
    public class InvoiceItem
    {
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
    }
}
