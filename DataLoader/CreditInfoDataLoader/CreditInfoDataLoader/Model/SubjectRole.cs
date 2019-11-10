using CreditInfoDataLoader.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditInfoDataLoader.Model
{
    public class SubjectRole
    {
        public string CustomerCode { get; set; }
        public RoleOfCustomer RoleOfCustomer { get; set; }
        public Amount GuaranteeAmount { get; set; }
    }
}
