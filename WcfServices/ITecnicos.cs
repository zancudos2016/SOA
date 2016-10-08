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
        SHMC_EMPL ObtenerTecnico(int COD_TECN);

        [OperationContract]
        List<SHMC_EMPL> ListarTecnicos();
    }
}
