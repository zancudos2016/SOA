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
    public interface IAtenciones
    {
        [FaultContract(typeof(GeneralException))]
        [OperationContract]
        SHMC_ATEN CrearAtencion(SHMC_ATEN atencionACrear);

        [OperationContract]
        SHMC_ATEN ObtenerAtencion(int COD_ATEN);

        [OperationContract]
        SHMC_ATEN ModificarAtencion(SHMC_ATEN atencionAModificar);

        [FaultContract(typeof(GeneralException))]
        [OperationContract]
        int EliminarAtencion(int COD_ATEN);

        [OperationContract]
        List<SHMC_ATEN> ListarAtenciones();
    }
}
