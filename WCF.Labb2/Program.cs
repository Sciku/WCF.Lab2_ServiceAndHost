using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using WCF_Service_BMI;

namespace WCF.Labb2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8080/WCF_Service_BMI");
            using (ServiceHost selfServiceHost = new ServiceHost(typeof(BMIService), baseAddress))
            {
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

                    Console.WriteLine("Tryck på ENTER för att stänga tjänsten");
                    Console.ReadLine();

                }
                catch (CommunicationException ex)
                {
                    Console.WriteLine(ex.Message);
                    selfServiceHost.Close();
                }
            }
                
        }
    }
}
