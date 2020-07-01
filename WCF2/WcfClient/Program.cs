using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WcfClient.ServiceReference1;
using WcfClient.ServiceReference2;

namespace WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {

            Service1Client klient1 = new Service1Client("BasicHttpBinding_IService1");

            CallbackHandler mojCallbackHandler = new CallbackHandler();
            InstanceContext instanceContext = new InstanceContext(mojCallbackHandler);
            CallbackService1Client klient3 = new CallbackService1Client(instanceContext);

            Service1Client klient2 = new Service1Client();

            bool exit = false;
            Image[] images;

            while (!exit)
            {
                Console.WriteLine(" ");
                Console.WriteLine("MENU");
                Console.WriteLine("\t1. Wyświetl listę obrazów");
                Console.WriteLine("\t2. Dodaj obraz");
                Console.WriteLine("\t3. Usuń obraz");
                Console.WriteLine("\t4. Wyświetl obraz podając jego id");
                Console.WriteLine("\t5. Wyświetl liczbę obrazów już załadowanych ");
                Console.WriteLine("\t6. Załaduj obrazek");
                Console.WriteLine("\t7. Pobierz obrazek");
                Console.WriteLine("\t8. Wyjście");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Lista obrazów");
                        images = klient1.GetImageList();
                        displayList(images);
                        Console.WriteLine("Naciśnij <ENTER> aby wyjść");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Dodawanie obraz");
                        Console.WriteLine("Podaj nazwę obrazu: ");
                        string name = Console.ReadLine();

                        Image img = new Image();
                        images = klient1.GetImageList();
                        int id = images.Length + 1;
                        img.Id = id;
                        img.IsUploaded = false;
                        img.Path = "Brak scieżki";
                        img.Name = name;
                        klient1.AddImageToList(img);
                        Console.WriteLine("Dodano pomyślnie");
                        Console.WriteLine("Naciśnij <ENTER> aby wyjść");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Usuwanie obraz");
                        Console.WriteLine("Podaj numer id obrazu: ");
                                              
                        int idNR = Int32.Parse(Console.ReadLine());
                        
                        klient1.RemoveImageToList(idNR);

                        Console.WriteLine("Usunięto pomyślnie");
                        Console.WriteLine("Naciśnij <ENTER> aby wyjść");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Wyświetlanie obraz");
                        Console.WriteLine("Podaj numer id obrazu: ");

                        int idNr2 = Int32.Parse(Console.ReadLine());

                        Image i = klient1.GetImageById(idNr2);
                        Console.WriteLine("Id" + "\t" + "Name" + "\t" + "         IsUploaded" + "\t" + "Path");
                        Console.WriteLine(i.Id + "\t" + i.Name + "\t" +  i.IsUploaded + "\t" + i.Path);
                        Console.WriteLine("Naciśnij <ENTER> aby wyjść");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Liczba załadowanych już obraz");
                        Console.WriteLine("-Rozpoczęcie wywoływania metody");
                        klient3.GetNumberOfUploadedImage();
                        Console.WriteLine("-Wyniki są w trakcie odbierania");
                        Console.WriteLine("Naciśnij <ENTER> aby wyjść");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Załadowywanie obrazu");
                        Console.WriteLine("Podaj indeks, do którego chcesz załadować obraz");
                
                        int numer = Int32.Parse(Console.ReadLine());

                        Image i2 = klient1.GetImageById(numer);
                        klient1.RemoveImageToList(numer);
                        string nameObraz = i2.Name + ".jpg";
                        string filePathUp = Path.Combine(System.Environment.CurrentDirectory,
                           nameObraz);
                        Console.WriteLine("Podaj ścieżkę, do pliku na swoim dysku. ( w formacie C:\\Users\\emila\\source\\repos\\WcfServiceLibrary2\\WcfHost\\bin\\Debug\\.\\image.jpg)");
                        string sciezka = Console.ReadLine();
                        System.IO.Stream streamUp = klient2.getStream(sciezka);

                        ZapiszPlik(streamUp, filePathUp);
                        i2.IsUploaded = true;
                        i2.Path = sciezka;
                        klient1.AddImageToList(i2);
                        Console.WriteLine("Naciśnij <ENTER> aby wyjść");
                        Console.ReadLine();
                        Console.Clear();

                        break;
                    case "7":
                        Console.Clear();
                        Console.WriteLine("Pobierane obrazu");

                        Console.WriteLine("Podaj indeks, z którego chcesz pobrać obraz");

                        string pathDown = "";
                        while (true)
                        {
                            int IdNr3 = Int32.Parse(Console.ReadLine());
                            Image i3 = klient1.GetImageById(IdNr3);
                            if (i3.IsUploaded)
                            {
                                pathDown = i3.Path;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Obraz z podanym indeksem nie posiada zaladowanego obrazu");
                            }

                        }
                        string filePathDown = Path.Combine(System.Environment.CurrentDirectory,
                           "cos.jpg");
                        Console.WriteLine(filePathDown);
                        string filePath2 = "C:\\Users\\emila\\source\\repos\\WcfServiceLibrary2\\WcfHost\\bin\\Debug\\.\\";

                        Console.WriteLine("Wpisz nazwę pobranego pliku:");
                        string pobranyplik = Console.ReadLine();

                        string nazwaOb2 = String.Concat(filePath2, pobranyplik);

                        System.IO.Stream stream3 = klient2.getStream(pathDown);
                        ZapiszPlik(stream3, nazwaOb2);


                        break;
                    case "8":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja menu, wpisz liczbę od 1 do 8!");
                        break;

                }

            }

            Console.WriteLine("Nacisnij <ENTER> aby zakonczyc."); Console.ReadLine();

            klient1.Close();
             klient2.Close();
            klient3.Close();





        }

        static void ZapiszPlik(System.IO.Stream instream, string filePath)
        {
            const int bufferLength = 8192; //długość bufora 8KB
            int bytecount = 0; //licznik
            int counter = 0; //licznik pomocniczy
            byte[] buffer = new byte[bufferLength];
            Console.WriteLine("--> Zapisuje plik {0}", filePath);
            FileStream outstream = File.Open(filePath, FileMode.Create,
            FileAccess.Write);
            //zapisywanie danych porcjami
            while ((counter = instream.Read(buffer, 0, bufferLength)) > 0)
            {
                outstream.Write(buffer, 0, counter);
                Console.Write(".{0}", counter); //wypisywanie info. po każdej części
                bytecount += counter;
            }
            Console.WriteLine();
            Console.WriteLine("Zapisano {0} bajtow", bytecount);
            outstream.Close();
            instream.Close();
            Console.WriteLine();
            Console.WriteLine("--> Plik {0} zapisany", filePath);
        }

      
        private static void displayList(Image[] image)
        {
            Console.WriteLine("Id" + "\t" + "Name" + "\t" + "      IsUploaded" + "\t" + "Path");

            for (int i = 0; i < image.Length; i++)
            {
                Console.WriteLine(image[i].Id + "\t" + image[i].Name + "\t" + image[i].IsUploaded + "\t" + image[i].Path);
            }
        }


    }
}
