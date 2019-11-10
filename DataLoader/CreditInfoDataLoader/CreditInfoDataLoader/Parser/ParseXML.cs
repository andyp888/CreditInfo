using CreditInfoDataLoader.Enums;
using CreditInfoDataLoader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace CreditInfoDataLoader.Parser
{
    public class ParseXML
    {
        private XNamespace ns = "http://creditinfo.com/schemas/Sample/Data";

        public IEnumerable<XElement> ParseContracts(string filePath)
        {
            //Load each Contract object
            using (XmlReader reader = XmlReader.Create(filePath))
            {
                reader.MoveToContent();
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element &&
                        reader.Name == "Contract")
                    {
                        XElement contract = XNode.ReadFrom(reader) as XElement;
                        if (contract != null)
                            yield return contract;

                    }
                }
            }
        }

        public Contract ParseContract(XElement contract)
        {
            var contractObj = new Contract();

            contractObj.ContractCode = (string) contract.Element(XName.Get("ContractCode",ns.NamespaceName)).Value;

            var contractData = contract.Element(XName.Get("ContractData", ns.NamespaceName));

            contractObj.PhaseOfContract = (PhaseOfContract) Enum.Parse(typeof(PhaseOfContract), (string)contractData.Element(XName.Get("PhaseOfContract", ns.NamespaceName)).Value);

            contractObj.CurrentBalanceAmount = ParseAmount(contractData.Element(XName.Get("OriginalAmount", ns.NamespaceName)));
            contractObj.InstallmentAmount = ParseAmount(contractData.Element(XName.Get("InstallmentAmount", ns.NamespaceName)));
            contractObj.OverdueBalanceAmount = ParseAmount(contractData.Element(XName.Get("OverdueBalance", ns.NamespaceName)));
            contractObj.CurrentBalanceAmount = ParseAmount(contractData.Element(XName.Get("CurrentBalance", ns.NamespaceName)));

            contractObj.DateOfLastPayment = (DateTime)contractData.Element(XName.Get("DateOfLastPayment", ns.NamespaceName));
            contractObj.DateOfNextPayment = (DateTime)contractData.Element(XName.Get("NextPaymentDate", ns.NamespaceName));
            contractObj.DateAccountOpened = (DateTime)contractData.Element(XName.Get("DateAccountOpened", ns.NamespaceName));
            contractObj.RealEndDate = (DateTime)contractData.Element(XName.Get("RealEndDate", ns.NamespaceName));

            contractObj.Individuals = ParseIndividuals(contract.Elements(XName.Get("Individual", ns.NamespaceName)).ToList());

            contractObj.SubjectRoles = ParseSubjectRoles(contract.Elements(XName.Get("SubjectRole", ns.NamespaceName)).ToList());

            return contractObj;
        }

        public Amount ParseAmount(XElement amount)
        {
            var amountObj = new Amount();

            amountObj.Currency = (string)amount.Element(XName.Get("Currency", ns.NamespaceName)).Value;
            amountObj.Value = Decimal.Parse(amount.Element(XName.Get("Value", ns.NamespaceName)).Value);

            return amountObj;
        }

        public List<Individual> ParseIndividuals(List<XElement> individuals)
        {
            //Parse individuals
            List<Individual> individualsList = new List<Individual>();
            return individualsList;
        }

        public List<SubjectRole> ParseSubjectRoles(List<XElement> subjectRoles)
        {
            //Parse subject roles
            List<SubjectRole> subjectRolesList = new List<SubjectRole>();
            return subjectRolesList;
        }
    }
}
