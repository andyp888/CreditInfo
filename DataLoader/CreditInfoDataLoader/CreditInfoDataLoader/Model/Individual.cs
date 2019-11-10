using CreditInfoDataLoader.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditInfoDataLoader.Model
{
    public class Individual
    {
        public string CustomerCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NationalId { get; set; }
    }
}
