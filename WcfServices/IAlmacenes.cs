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
    public interface IAlmacenes
    {
        [OperationContract]
        SHMC_ALMA ObtenerAlmacen(int COD_ALMA);

        [OperationContract]
        List<SHMC_ALMA> ListarAlmacenes();
    }
}
