﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfClient.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Image", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceLibrary2")]
    [System.SerializableAttribute()]
    public partial class Image : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsUploadedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PathField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsUploaded {
            get {
                return this.IsUploadedField;
            }
            set {
                if ((this.IsUploadedField.Equals(value) != true)) {
                    this.IsUploadedField = value;
                    this.RaisePropertyChanged("IsUploaded");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Path {
            get {
                return this.PathField;
            }
            set {
                if ((object.ReferenceEquals(this.PathField, value) != true)) {
                    this.PathField = value;
                    this.RaisePropertyChanged("Path");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getStream", ReplyAction="http://tempuri.org/IService1/getStreamResponse")]
        System.IO.Stream getStream(string nazwa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getStream", ReplyAction="http://tempuri.org/IService1/getStreamResponse")]
        System.Threading.Tasks.Task<System.IO.Stream> getStreamAsync(string nazwa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetImageById", ReplyAction="http://tempuri.org/IService1/GetImageByIdResponse")]
        WcfClient.ServiceReference1.Image GetImageById(int imageId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetImageById", ReplyAction="http://tempuri.org/IService1/GetImageByIdResponse")]
        System.Threading.Tasks.Task<WcfClient.ServiceReference1.Image> GetImageByIdAsync(int imageId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddImageToList", ReplyAction="http://tempuri.org/IService1/AddImageToListResponse")]
        void AddImageToList(WcfClient.ServiceReference1.Image image);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddImageToList", ReplyAction="http://tempuri.org/IService1/AddImageToListResponse")]
        System.Threading.Tasks.Task AddImageToListAsync(WcfClient.ServiceReference1.Image image);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/RemoveImageToList", ReplyAction="http://tempuri.org/IService1/RemoveImageToListResponse")]
        void RemoveImageToList(int imageId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/RemoveImageToList", ReplyAction="http://tempuri.org/IService1/RemoveImageToListResponse")]
        System.Threading.Tasks.Task RemoveImageToListAsync(int imageId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetImageList", ReplyAction="http://tempuri.org/IService1/GetImageListResponse")]
        WcfClient.ServiceReference1.Image[] GetImageList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetImageList", ReplyAction="http://tempuri.org/IService1/GetImageListResponse")]
        System.Threading.Tasks.Task<WcfClient.ServiceReference1.Image[]> GetImageListAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : WcfClient.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<WcfClient.ServiceReference1.IService1>, WcfClient.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.IO.Stream getStream(string nazwa) {
            return base.Channel.getStream(nazwa);
        }
        
        public System.Threading.Tasks.Task<System.IO.Stream> getStreamAsync(string nazwa) {
            return base.Channel.getStreamAsync(nazwa);
        }
        
        public WcfClient.ServiceReference1.Image GetImageById(int imageId) {
            return base.Channel.GetImageById(imageId);
        }
        
        public System.Threading.Tasks.Task<WcfClient.ServiceReference1.Image> GetImageByIdAsync(int imageId) {
            return base.Channel.GetImageByIdAsync(imageId);
        }
        
        public void AddImageToList(WcfClient.ServiceReference1.Image image) {
            base.Channel.AddImageToList(image);
        }
        
        public System.Threading.Tasks.Task AddImageToListAsync(WcfClient.ServiceReference1.Image image) {
            return base.Channel.AddImageToListAsync(image);
        }
        
        public void RemoveImageToList(int imageId) {
            base.Channel.RemoveImageToList(imageId);
        }
        
        public System.Threading.Tasks.Task RemoveImageToListAsync(int imageId) {
            return base.Channel.RemoveImageToListAsync(imageId);
        }
        
        public WcfClient.ServiceReference1.Image[] GetImageList() {
            return base.Channel.GetImageList();
        }
        
        public System.Threading.Tasks.Task<WcfClient.ServiceReference1.Image[]> GetImageListAsync() {
            return base.Channel.GetImageListAsync();
        }
    }
}
