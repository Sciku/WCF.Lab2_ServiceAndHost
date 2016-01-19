using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using WCF_Service_Days;

namespace WCF.Labb2.Days
{
    public class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8080/WCF_Service_Days");
            using (ServiceHost selfServiceHost = new ServiceHost(typeof(DaysService), baseAddress))
            {
                try
                {
                    selfServiceHost.AddServiceEndpoint
                     (typeof(IDays),
                     new WSHttpBinding(),
                     "DaysService");

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
