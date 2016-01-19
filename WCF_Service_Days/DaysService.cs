using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WCF_Service_Days
{
    [ServiceContract(Namespace = "WCF_Service_Days")]
    public interface IDays
    {
        [OperationContract]
        double DaysOld(int year, int month, int day);
    }

    public class DaysService : IDays
    {
        public double DaysOld(int year, int month, int day)
        {
            Console.WriteLine("Mottaget");
            var today = new DateTime();
            var birthday = new DateTime(year, month, day);
            var calc = (today.Date - birthday.Date).TotalDays;
            return calc;
        }
    }
}
