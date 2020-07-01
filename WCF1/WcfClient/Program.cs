using System;
using WcfClient.ServiceReference1;
using WcfClient.ServiceReference2;
using WcfClient.ServiceReference3;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //Krok 1: Utworzenie instancji WCF proxy.

            InfoClient klient1 = new InfoClient("WSHttpBinding_IInfo1");
            Isrv112Client klient2 = new Isrv112Client("WSHttpBinding_Isrv1121");
            Service1Client klient3 = new Service1Client("WSHttpBinding_IService1");

            // Krok 2: Wywolanie operacji uslugi.

            string result = klient1.getInfo("Lebiedowska", "Emilia", 242473);
            int result1 = klient2.oper112(3.9F, 242473, "Lebiedowska");
            int result2 = klient2.oper112(3.9F, 242473, "Lebiedowska");

            Console.WriteLine("Wynik dla 1 endpointa: " + result);
            Console.WriteLine("Wynik dla 2 endpointa: " + result1);
            Console.WriteLine("Wynik dla 3 endpointa z lokalnego serwera: " + result2);


            // Krok 3: Zamknięcie klienta zamyka polaczenie i czysci zasoby

            klient1.Close();
            klient2.Close();
            klient3.Close();

        }
    }
}
