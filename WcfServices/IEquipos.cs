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
        SHMC_EQUI ObtenerEquipo(int COD_EQUI);

        [OperationContract]
        SHMC_EQUI ModificarEquipo(SHMC_EQUI equipoAModificar);

        [OperationContract]
        List<SHMC_EQUI> ListarEquipos(int COD_TECN);
    }
}
