using CreditInfoDataLoader.Model;
using CreditInfoDataLoader.Parser;
using CreditInfoDataLoader.Validation;
using System.Configuration;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace CreditInfoDataLoader
{
    public class Program
    {
        static void Main(string[] args)
        {
            var value = ConfigurationManager.AppSettings["filePath"];

            Program program = new Program();
            ValidateContract validation = new ValidateContract();
            ParseXML parseXML = new ParseXML();
            var contracts = parseXML.ParseContracts(value);

            foreach (XElement xelement in contracts)
            {
                Contract result = parseXML.ParseContract(xelement);

                if (validation.ValidiateContract(result))
                {
                    program.InsertToDB(result);
                }
            }

        }
        public void InsertToDB(Contract contract)
        {
                var connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    //save content to DB
                }
            }
        }
    }
