using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServices
{
    [ServiceContract]
    public interface IReportes
    {
        [OperationContract]
        int RegistarReporte(SHMD_ATEN_REPO reporteARegistrar);

        [OperationContract]
        bool RegularizarReportes();

        [OperationContract]
        SHMD_ATEN_REPO ObtenerReporte(int COD_ATEN_REPO);

        [OperationContract]
        SHMD_ATEN_REPO ModificarReporte(SHMD_ATEN_REPO reporteAModificar);
    }
}
