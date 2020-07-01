using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary2
{
    [ServiceContract]
    public interface ICallbackHandler
    {
        [OperationContract(IsOneWay = true)] void ZwrotGetNumberOfUploadedImage(int result);
    }

    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(ICallbackHandler))]
    public interface ICallbackService1
    {
        [OperationContract(IsOneWay = true)] void GetNumberOfUploadedImage();
    }

    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        System.IO.Stream getStream(string nazwa);

        [OperationContract]
        Image GetImageById(int imageId);

        [OperationContract]
        void AddImageToList(Image image);

        [OperationContract]
        void RemoveImageToList(int imageId);

        [OperationContract]
        List<Image> GetImageList();
    }

    [DataContract]
    public class Image
    {
        int id;
        bool isUploaded = false;
        string path = "";
        string name = "";

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public bool IsUploaded
        {
            get { return isUploaded; }
            set { isUploaded = value; }
        }

        [DataMember]
        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }


}
