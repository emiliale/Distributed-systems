using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary2;

namespace WcfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:10069/Lebiedowska");
            Uri baseAddress3 = new Uri("http://localhost:10071/Lebiedowska3");

            ServiceHost mojHost = new ServiceHost(typeof(Service1),baseAddress);
            ServiceHost mojHost3 = new ServiceHost(typeof(Service1), baseAddress3);

            BasicHttpBinding b = new BasicHttpBinding();
            b.TransferMode = TransferMode.Streamed;
            b.MaxReceivedMessageSize = 1000000000;
            b.MaxBufferSize = 8192;

            WSDualHttpBinding mojBanding3 = new WSDualHttpBinding();


            try
            {
                ServiceEndpoint endpoint = mojHost.AddServiceEndpoint(typeof(IService1), b, baseAddress);
                ServiceEndpoint endpoint3 = mojHost3.AddServiceEndpoint(typeof(ICallbackService1), mojBanding3, "endpoint3");


                // Metadane:
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                ServiceMetadataBehavior smb3 = new ServiceMetadataBehavior();

                smb.HttpGetEnabled = true;
                smb3.HttpGetEnabled = true;

                mojHost3.Description.Behaviors.Add(smb3);
                mojHost3.Open();
                Console.WriteLine("--->Callback uruchomiony.");

                mojHost.Description.Behaviors.Add(smb);
                mojHost.Open();
                Console.WriteLine("--->Serwer jest uruchomiony.");
                Console.WriteLine("--->Nacisnij <ENTER> aby zakonczyc.\n");
                Console.ReadLine(); //czekam na zamkniecie

                mojHost.Close();
                mojHost3.Close();

                Console.WriteLine("---> Serwis zakonczyl dzialanie.");
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("Wystapil wyjatek: {0}", ce.Message);
                mojHost.Abort();
                mojHost3.Abort();

            }

        }
    }
}
