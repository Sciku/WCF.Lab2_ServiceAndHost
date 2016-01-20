using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using WCF_Service_Hobby;
namespace WCF.Labb2.Hobby
{
    public class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8080/WCF_service_Hobby");

            using (ServiceHost selfServiceHost = new ServiceHost(typeof(HobbyService), baseAddress))
            {
                try
                {
                    selfServiceHost.AddServiceEndpoint
                        (typeof(IHobby), 
                        new WSHttpBinding(), 
                        "HobbyService");

                    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                    smb.HttpGetEnabled = true;

                    selfServiceHost.Description.Behaviors.Add(smb);

                    selfServiceHost.Open();
                    Console.WriteLine("The gates are open!");
                    Console.WriteLine("Tryck på ENTER för att avsluta tjänsten");
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
