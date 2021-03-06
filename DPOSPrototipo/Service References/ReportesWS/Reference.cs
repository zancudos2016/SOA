﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DPOSPrototipo.ReportesWS {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ReportesWS.IReportes")]
    public interface IReportes {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportes/RegistarReporte", ReplyAction="http://tempuri.org/IReportes/RegistarReporteResponse")]
        int RegistarReporte(Entidades.SHMD_ATEN_REPO reporteARegistrar);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportes/RegistarReporte", ReplyAction="http://tempuri.org/IReportes/RegistarReporteResponse")]
        System.Threading.Tasks.Task<int> RegistarReporteAsync(Entidades.SHMD_ATEN_REPO reporteARegistrar);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportes/RegularizarReportes", ReplyAction="http://tempuri.org/IReportes/RegularizarReportesResponse")]
        bool RegularizarReportes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportes/RegularizarReportes", ReplyAction="http://tempuri.org/IReportes/RegularizarReportesResponse")]
        System.Threading.Tasks.Task<bool> RegularizarReportesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportes/ObtenerReporte", ReplyAction="http://tempuri.org/IReportes/ObtenerReporteResponse")]
        Entidades.SHMD_ATEN_REPO ObtenerReporte(int COD_ATEN_REPO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportes/ObtenerReporte", ReplyAction="http://tempuri.org/IReportes/ObtenerReporteResponse")]
        System.Threading.Tasks.Task<Entidades.SHMD_ATEN_REPO> ObtenerReporteAsync(int COD_ATEN_REPO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportes/ModificarReporte", ReplyAction="http://tempuri.org/IReportes/ModificarReporteResponse")]
        Entidades.SHMD_ATEN_REPO ModificarReporte(Entidades.SHMD_ATEN_REPO reporteAModificar);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReportes/ModificarReporte", ReplyAction="http://tempuri.org/IReportes/ModificarReporteResponse")]
        System.Threading.Tasks.Task<Entidades.SHMD_ATEN_REPO> ModificarReporteAsync(Entidades.SHMD_ATEN_REPO reporteAModificar);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IReportesChannel : DPOSPrototipo.ReportesWS.IReportes, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ReportesClient : System.ServiceModel.ClientBase<DPOSPrototipo.ReportesWS.IReportes>, DPOSPrototipo.ReportesWS.IReportes {
        
        public ReportesClient() {
        }
        
        public ReportesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ReportesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReportesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReportesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int RegistarReporte(Entidades.SHMD_ATEN_REPO reporteARegistrar) {
            return base.Channel.RegistarReporte(reporteARegistrar);
        }
        
        public System.Threading.Tasks.Task<int> RegistarReporteAsync(Entidades.SHMD_ATEN_REPO reporteARegistrar) {
            return base.Channel.RegistarReporteAsync(reporteARegistrar);
        }
        
        public bool RegularizarReportes() {
            return base.Channel.RegularizarReportes();
        }
        
        public System.Threading.Tasks.Task<bool> RegularizarReportesAsync() {
            return base.Channel.RegularizarReportesAsync();
        }
        
        public Entidades.SHMD_ATEN_REPO ObtenerReporte(int COD_ATEN_REPO) {
            return base.Channel.ObtenerReporte(COD_ATEN_REPO);
        }
        
        public System.Threading.Tasks.Task<Entidades.SHMD_ATEN_REPO> ObtenerReporteAsync(int COD_ATEN_REPO) {
            return base.Channel.ObtenerReporteAsync(COD_ATEN_REPO);
        }
        
        public Entidades.SHMD_ATEN_REPO ModificarReporte(Entidades.SHMD_ATEN_REPO reporteAModificar) {
            return base.Channel.ModificarReporte(reporteAModificar);
        }
        
        public System.Threading.Tasks.Task<Entidades.SHMD_ATEN_REPO> ModificarReporteAsync(Entidades.SHMD_ATEN_REPO reporteAModificar) {
            return base.Channel.ModificarReporteAsync(reporteAModificar);
        }
    }
}
