﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewBase.Payment.STCPAY.Model
{
    public class RefundPaymentRequestMessage
    {
        public string STCPayRefNum { get; set; }
        public int Amount { get; set; }
    }
}