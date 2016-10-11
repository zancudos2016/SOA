using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServices.Persistencia;

namespace WcfServices
{
    public class Facilidades : IFacilidades
    {
        private FacilidadDAO facilidadDAO = new FacilidadDAO();
        // el servicio de facilidades contiene los metodos de registrar y listar
        public int RegistrarAtencionFacilidad(SHMD_ATEN_REPO_FACI atenfaciARegistrar)
        {
 
            return facilidadDAO.RegistrarAtenFaci(atenfaciARegistrar);
        }

        public List<SHMC_FACI> ListarFacilidades()
        {

            return facilidadDAO.Listar();
        }
    }
}
