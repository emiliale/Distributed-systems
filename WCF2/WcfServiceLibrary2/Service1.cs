using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace WcfServiceLibrary2
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Service1 : IService1, ICallbackService1
    {
        static List<Image> images = new List<Image>();
        int result;
        ICallbackHandler callback = null;

        public System.IO.Stream getStream(string data)
        {
            FileStream myFile;
            Console.WriteLine("-->Wywolano getStream");
            string filePath = data;
           
            // wyjatek na wypadek bledu otwarcia pliku
            try
            {
                myFile = File.OpenRead(filePath);
            }
            catch (IOException ex)
            {
                Console.WriteLine(String.Format("Wyjatek otwarcia pliku {0} :",
                filePath));
                Console.WriteLine(ex.ToString());
                throw ex;
            }
            return myFile;
        }

        public void AddImageToList(Image image)
        {
            images.Add(image);

        }

        public Image GetImageById(int imageId)
        {
            return images.Find(i => i.Id == imageId);

        }

        public List<Image> GetImageList()
        {
            return images;
        }

        public void GetNumberOfUploadedImage()
        {
            callback = OperationContext.Current.GetCallbackChannel
           <ICallbackHandler>();
            Console.WriteLine("Znajdowanie elementów- start");
            Thread.Sleep(4 * 1000); // tu 4 sekundy (40000 ms)
            int sum = 0;
            for (int i = 0; i < images.Count; i++)
            {
                if (images[i].IsUploaded == true)
                {
                    sum++;
                }
            }
            Console.WriteLine("Znajdowanie elementów - stop");
            result = sum;
            callback.ZwrotGetNumberOfUploadedImage(result);

        }

        public void RemoveImageToList(int imageId)
        {
            int index = images.FindIndex(i => i.Id == imageId);
            images.RemoveAt(index);
        }
    }

}

