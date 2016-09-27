using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
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
    }
}
