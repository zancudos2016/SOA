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
    public interface ITecnicos
    {
        [OperationContract]
        List<SHMC_EMPL> ListarTecnicos();

        [FaultContract(typeof(GeneralException))]
        [OperationContract]
        SHMC_USUA LoginTecnico(SHMC_USUA usuarioABuscar);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Tecnicos/{COD_TECN}", ResponseFormat = WebMessageFormat.Json)]
        List<SHMC_ATEN> Listar(string COD_TECN);
    }
}
