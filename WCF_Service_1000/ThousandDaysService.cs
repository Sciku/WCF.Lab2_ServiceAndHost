using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WCF_Service_ThousandDays
{
    [ServiceContract(Namespace = "WCF_Service_ThousandDays")]
    public interface IThousandDays
    {
        [OperationContract]
        double days(int year, int month, int day);
    }
    public class ThousandDaysService : IThousandDays
    {
        public double days(int year, int month, int day)
        {
            Console.WriteLine("Mottaget");
            var today = DateTime.Now;
            var birthday = new DateTime(year, month, day);
            var calc = 1000 - (today.Date - birthday.Date).Days % 1000;
            return calc;
        }
    }
}
