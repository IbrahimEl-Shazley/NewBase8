﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBase.Payment.MyFatoorah.Model
{
    public class InitiatePayment
    {
        public string InvoiceAmount { get; set; }
        public string CurrencyIso { get; set; }
    }
}