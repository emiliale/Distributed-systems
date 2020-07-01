using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfClient.ServiceReference2;

namespace WcfClient
{
    class CallbackHandler : ICallbackService1Callback
    {
        public void ZwrotGetNumberOfUploadedImage(int result)
        {
            Console.WriteLine(" Liczba zdjęc zuploadowanych = {0}", result);
        }
    }
}
