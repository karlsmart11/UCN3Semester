﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KarmaClient.TableServiceRef {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Table", Namespace="http://schemas.datacontract.org/2004/07/Model")]
    [System.SerializableAttribute()]
    public partial class Table : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SeatsField;
        
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
        public int Seats {
            get {
                return this.SeatsField;
            }
            set {
                if ((this.SeatsField.Equals(value) != true)) {
                    this.SeatsField = value;
                    this.RaisePropertyChanged("Seats");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Error", Namespace="http://schemas.datacontract.org/2004/07/Model")]
    [System.SerializableAttribute()]
    public partial class Error : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodigoErrorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MensajeField;
        
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
        public string CodigoError {
            get {
                return this.CodigoErrorField;
            }
            set {
                if ((object.ReferenceEquals(this.CodigoErrorField, value) != true)) {
                    this.CodigoErrorField = value;
                    this.RaisePropertyChanged("CodigoError");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Mensaje {
            get {
                return this.MensajeField;
            }
            set {
                if ((object.ReferenceEquals(this.MensajeField, value) != true)) {
                    this.MensajeField = value;
                    this.RaisePropertyChanged("Mensaje");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TableServiceRef.ITableServices")]
    public interface ITableServices {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITableServices/InsertTable", ReplyAction="http://tempuri.org/ITableServices/InsertTableResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(KarmaClient.TableServiceRef.Error), Action="http://tempuri.org/ITableServices/InsertTableErrorFault", Name="Error", Namespace="http://schemas.datacontract.org/2004/07/Model")]
        KarmaClient.TableServiceRef.Table InsertTable(KarmaClient.TableServiceRef.Table table);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITableServices/InsertTable", ReplyAction="http://tempuri.org/ITableServices/InsertTableResponse")]
        System.Threading.Tasks.Task<KarmaClient.TableServiceRef.Table> InsertTableAsync(KarmaClient.TableServiceRef.Table table);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITableServices/GetAllTables", ReplyAction="http://tempuri.org/ITableServices/GetAllTablesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(KarmaClient.TableServiceRef.Error), Action="http://tempuri.org/ITableServices/GetAllTablesErrorFault", Name="Error", Namespace="http://schemas.datacontract.org/2004/07/Model")]
        System.Collections.Generic.List<KarmaClient.TableServiceRef.Table> GetAllTables();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITableServices/GetAllTables", ReplyAction="http://tempuri.org/ITableServices/GetAllTablesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<KarmaClient.TableServiceRef.Table>> GetAllTablesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITableServices/GetTablesBySeats", ReplyAction="http://tempuri.org/ITableServices/GetTablesBySeatsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(KarmaClient.TableServiceRef.Error), Action="http://tempuri.org/ITableServices/GetTablesBySeatsErrorFault", Name="Error", Namespace="http://schemas.datacontract.org/2004/07/Model")]
        System.Collections.Generic.List<KarmaClient.TableServiceRef.Table> GetTablesBySeats(int seats);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITableServices/GetTablesBySeats", ReplyAction="http://tempuri.org/ITableServices/GetTablesBySeatsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<KarmaClient.TableServiceRef.Table>> GetTablesBySeatsAsync(int seats);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITableServices/GetAvailableTables", ReplyAction="http://tempuri.org/ITableServices/GetAvailableTablesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(KarmaClient.TableServiceRef.Error), Action="http://tempuri.org/ITableServices/GetAvailableTablesErrorFault", Name="Error", Namespace="http://schemas.datacontract.org/2004/07/Model")]
        System.Collections.Generic.List<KarmaClient.TableServiceRef.Table> GetAvailableTables(string DesiredTime);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITableServices/GetAvailableTables", ReplyAction="http://tempuri.org/ITableServices/GetAvailableTablesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<KarmaClient.TableServiceRef.Table>> GetAvailableTablesAsync(string DesiredTime);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITableServicesChannel : KarmaClient.TableServiceRef.ITableServices, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TableServicesClient : System.ServiceModel.ClientBase<KarmaClient.TableServiceRef.ITableServices>, KarmaClient.TableServiceRef.ITableServices {
        
        public TableServicesClient() {
        }
        
        public TableServicesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TableServicesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TableServicesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TableServicesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public KarmaClient.TableServiceRef.Table InsertTable(KarmaClient.TableServiceRef.Table table) {
            return base.Channel.InsertTable(table);
        }
        
        public System.Threading.Tasks.Task<KarmaClient.TableServiceRef.Table> InsertTableAsync(KarmaClient.TableServiceRef.Table table) {
            return base.Channel.InsertTableAsync(table);
        }
        
        public System.Collections.Generic.List<KarmaClient.TableServiceRef.Table> GetAllTables() {
            return base.Channel.GetAllTables();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<KarmaClient.TableServiceRef.Table>> GetAllTablesAsync() {
            return base.Channel.GetAllTablesAsync();
        }
        
        public System.Collections.Generic.List<KarmaClient.TableServiceRef.Table> GetTablesBySeats(int seats) {
            return base.Channel.GetTablesBySeats(seats);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<KarmaClient.TableServiceRef.Table>> GetTablesBySeatsAsync(int seats) {
            return base.Channel.GetTablesBySeatsAsync(seats);
        }
        
        public System.Collections.Generic.List<KarmaClient.TableServiceRef.Table> GetAvailableTables(string DesiredTime) {
            return base.Channel.GetAvailableTables(DesiredTime);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<KarmaClient.TableServiceRef.Table>> GetAvailableTablesAsync(string DesiredTime) {
            return base.Channel.GetAvailableTablesAsync(DesiredTime);
        }
    }
}
