using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WCF_Service_BMI
{
    [ServiceContract(Namespace = "WCF_Service_BMI")]
    public interface IBMI
    {
        [OperationContract]
        decimal BMI(decimal height, decimal weight);
    }

    public class BMIService : IBMI
    {
        public decimal BMI(decimal height, decimal weight)
        {
            Console.WriteLine("Mottaget");
            return weight / ((height / 100) * (height / 100));
        }
    }
}
