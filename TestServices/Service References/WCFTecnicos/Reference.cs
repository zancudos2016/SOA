﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestServices.WCFTecnicos {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SHMC_EMPL", Namespace="http://schemas.datacontract.org/2004/07/Entidades")]
    [System.SerializableAttribute()]
    public partial class SHMC_EMPL : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ALF_EMPLField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int COD_TECNField;
        
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
        public string ALF_EMPL {
            get {
                return this.ALF_EMPLField;
            }
            set {
                if ((object.ReferenceEquals(this.ALF_EMPLField, value) != true)) {
                    this.ALF_EMPLField = value;
                    this.RaisePropertyChanged("ALF_EMPL");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int COD_TECN {
            get {
                return this.COD_TECNField;
            }
            set {
                if ((this.COD_TECNField.Equals(value) != true)) {
                    this.COD_TECNField = value;
                    this.RaisePropertyChanged("COD_TECN");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WCFTecnicos.ITecnicos")]
    public interface ITecnicos {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITecnicos/ListarTecnicos", ReplyAction="http://tempuri.org/ITecnicos/ListarTecnicosResponse")]
        TestServices.WCFTecnicos.SHMC_EMPL[] ListarTecnicos();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITecnicos/ListarTecnicos", ReplyAction="http://tempuri.org/ITecnicos/ListarTecnicosResponse")]
        System.Threading.Tasks.Task<TestServices.WCFTecnicos.SHMC_EMPL[]> ListarTecnicosAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITecnicosChannel : TestServices.WCFTecnicos.ITecnicos, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TecnicosClient : System.ServiceModel.ClientBase<TestServices.WCFTecnicos.ITecnicos>, TestServices.WCFTecnicos.ITecnicos {
        
        public TecnicosClient() {
        }
        
        public TecnicosClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TecnicosClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TecnicosClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TecnicosClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public TestServices.WCFTecnicos.SHMC_EMPL[] ListarTecnicos() {
            return base.Channel.ListarTecnicos();
        }
        
        public System.Threading.Tasks.Task<TestServices.WCFTecnicos.SHMC_EMPL[]> ListarTecnicosAsync() {
            return base.Channel.ListarTecnicosAsync();
        }
    }
}