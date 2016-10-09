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
    public interface IFacilidades
    {
        [OperationContract]
        int RegistrarAtencionFacilidad(SHMD_ATEN_REPO_FACI atenfaciARegistrar);

        [OperationContract]
        List<SHMC_FACI> ListarFacilidades();
    }
}
