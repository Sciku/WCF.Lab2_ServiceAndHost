using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using WCF_Service;

namespace WCF.Labb2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8080/WCF_Service");
            ServiceHost selfServiceHost = new ServiceHost(typeof(BMIService), baseAddress);
            try
            {
                selfServiceHost.AddServiceEndpoint
                    (typeof(IBMI),
                    new WSHttpBinding(),
                    "BMIService");

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;

                selfServiceHost.Description.Behaviors.Add(smb);

                selfServiceHost.Open();
                Console.WriteLine("The gates are open!");
            }
            finally
            {
                Console.WriteLine("Tryck på ENTER för att stänga tjänsten");
                Console.ReadLine();
                selfServiceHost.Close();
            }
        }
    }
}
