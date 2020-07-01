using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LebiedowskaMojWebSerwis
{
    [ServiceContract]
    public interface IRestSerwis1
    {
        // XML

        [OperationContract]
        [WebGet(UriTemplate = "/xml/products")]
        List<Product> getXmlAll();

        [OperationContract]
        [WebGet(UriTemplate = "/xml/products/{id}", RequestFormat = WebMessageFormat.Xml)]
        Product getXmlById(string Id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/xml/products", Method = "POST", RequestFormat = WebMessageFormat.Xml)]
        string addXml(Product element);

        [OperationContract]
        [WebInvoke(UriTemplate = "/xml/products/{id}", Method = "DELETE")]
        string deleteXml(string Id);
        
        [OperationContract]
        [WebInvoke(UriTemplate = "/xml/products/{id}", Method = "PUT", RequestFormat = WebMessageFormat.Xml)]
        string editXml(string Id, Product element);

        // JSON

        [OperationContract]
        [WebGet(UriTemplate = "/json/products", ResponseFormat = WebMessageFormat.Json)]
        List<Product> getJsonAll();

        [OperationContract]
        [WebGet(UriTemplate = "/json/products/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Product getJsonById(string Id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/products", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string addJson(Product element);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/products/{id}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
        string deleteJson(string Id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/products/{id}", Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string editJson(string Id, Product element);
    }

    [DataContract]
    public class Product
    {
        [DataMember(Order = 0)]
        public int Id;

        [DataMember(Order = 1)]
        public string Name;

        [DataMember(Order = 2)]
        public string Category;

        [DataMember(Order = 3)]
        public double Price;
    }
}
