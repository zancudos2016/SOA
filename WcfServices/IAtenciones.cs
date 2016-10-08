using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfServices.Errores;

namespace WcfServices
{
    [ServiceContract]
    public interface IAtenciones
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Atenciones", ResponseFormat = WebMessageFormat.Json)]
        SHMC_ATEN Crear(SHMC_ATEN atencionACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Atenciones/{COD_ATEN}", ResponseFormat = WebMessageFormat.Json)]
        SHMC_ATEN Obtener(string COD_ATEN);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Atenciones", ResponseFormat = WebMessageFormat.Json)]
        SHMC_ATEN Modificar(SHMC_ATEN atencionAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Atenciones/{COD_ATEN}", ResponseFormat = WebMessageFormat.Json)]
        int Eliminar(string COD_ATEN);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Atenciones", ResponseFormat = WebMessageFormat.Json)]
        List<SHMC_ATEN> Listar();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Atenciones?COD_TECN={COD_TECN}", ResponseFormat = WebMessageFormat.Json)]
        List<SHMC_ATEN> ListarPorTecnico(string COD_TECN);

        //?search=(COD_TECN=[parametro])
    }
}
