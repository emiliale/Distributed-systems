using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LebiedowskaMojWebSerwis
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IRestSerwis1
    {
        private static List<Product> products;

        public Service1()
        {
            products = new List<Product>()
            {
                new Product {Id = 0, Name = "Hummus", Category = "Żywność", Price = 5.99},
                new Product {Id = 1, Name = "Szampon", Category = "Kosmetyki", Price = 15.49},
                new Product {Id = 2, Name = "Kiełbasa", Category = "Żywność", Price = 8.59}
            };
        }

        public string addJson(Product element)
        {
            if (element == null)
                throw new WebFaultException<string>("400: Bad Request", HttpStatusCode.BadRequest);

            int idx = products.FindIndex(b => b.Id == element.Id);

            if (idx == -1)
            {
                products.Add(element);
                return "Dodano produkt z ID=" + element.Id;
            }
            else throw new WebFaultException<string>("409: Conflict", HttpStatusCode.Conflict);
        }

        public string addXml(Product element)
        {
            if (element == null)
                throw new WebFaultException<string>("400: Bad Request", HttpStatusCode.BadRequest);

            int idx = products.FindIndex(b => b.Id == element.Id);

            if (idx == -1)
            {
                products.Add(element);
                return "Dodano produkt z=" + element.Id;
            }
            else throw new WebFaultException<string>("409: Conflict", HttpStatusCode.Conflict);
        }

        public string deleteJson(string Id)
        {
            int intId = int.Parse(Id);
            int idx = products.FindIndex(b => b.Id == intId);

            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);

            products.RemoveAt(idx);
            return "Usunieto ksiazke o id=" + Id;
        }

        public string deleteXml(string Id)
        {
            int intId = int.Parse(Id);
            int idx = products.FindIndex(b => b.Id == intId);

            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);

            products.RemoveAt(idx);
            return "Usunieto produkt o id=" + Id;
        }

        public string editJson(string Id, Product element)
        {
            int intId = int.Parse(Id);
            int idx = products.FindIndex(b => b.Id == intId);

            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);
            products.RemoveAt(idx);

            products.Insert(idx, element);
            return "ZModyfikowano produkt o id=" + Id;
        }

        public string editXml(string Id, Product element)
        {
            int intId = int.Parse(Id);
            int idx = products.FindIndex(b => b.Id == intId);

            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);
            products.RemoveAt(idx);

            products.Insert(idx, element);
            return "ZModyfikowano produkt o id=" + Id;
        }

        public List<Product> getJsonAll()
        {
            return products;
        }

        public Product getJsonById(string Id)
        {
            int intId = int.Parse(Id);
            int idx = products.FindIndex(b => b.Id == intId);

            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);

            return products.ElementAt(idx);
        }

        public List<Product> getXmlAll()
        {
            return products;
        }

        public Product getXmlById(string Id)
        {
            int intId = int.Parse(Id);
            int idx = products.FindIndex(b => b.Id == intId);

            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);

            return products.ElementAt(idx);
        }
    }
}
