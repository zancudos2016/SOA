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
    public interface IEquipos
    {
        [OperationContract]
        SHMC_EQUI ObtenerAtencion(int COD_EQUI);

        [OperationContract]
        SHMC_EQUI ModificarAtencion(SHMC_EQUI equipoAModificar);

        [OperationContract]
        List<SHMC_EQUI> ListarAtenciones(int COD_TECN);
    }
}
