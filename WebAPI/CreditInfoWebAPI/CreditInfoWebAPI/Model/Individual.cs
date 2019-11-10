using CreditInfoWebAPI.Enum;
using System;
namespace CreditInfoWebAPI.Model
{
    public class Individual
    {
        public string CustomerCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NationalId { get; set; }

        public ContractInfo ContractInfo { get; set; }
    }
}
