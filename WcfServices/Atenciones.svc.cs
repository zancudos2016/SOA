using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfServices.Errores;
using WcfServices.Persistencia;

namespace WcfServices
{
    public class Atenciones : IAtenciones
    {
        private AtencionDAO atencionDAO = new AtencionDAO();
        public Entidades.SHMC_ATEN Crear(Entidades.SHMC_ATEN atencionACrear)
        {
            if (atencionDAO.Obtener(atencionACrear.COD_ATEN) != null) //Ya existe
            {
                throw new WebFaultException<string>("La atención ya existe", HttpStatusCode.NotAcceptable);
            }

            return atencionDAO.Crear(atencionACrear);
        }

        public Entidades.SHMC_ATEN Obtener(string COD_ATEN)
        {
            var atencion = atencionDAO.Obtener(Convert.ToInt32(COD_ATEN));
            if (atencion == null) //No existe
            {
                throw new WebFaultException<string>("La atención no existe", HttpStatusCode.NotAcceptable);
            }
            return atencion;
        }

        public Entidades.SHMC_ATEN Modificar(Entidades.SHMC_ATEN atencionAModificar)
        {
            var atencion = atencionDAO.Obtener(atencionAModificar.COD_ATEN);
            if (atencion == null) //No existe
            {
                throw new WebFaultException<string>("La atención no existe", HttpStatusCode.NotAcceptable);
            }
            if (string.IsNullOrEmpty(atencionAModificar.FEC_PROG))
            {
                return atencionDAO.Modificar(atencionAModificar);
            }
            else
            {
                return atencionDAO.Programar(atencionAModificar);
            }
        }

        public int Eliminar(string COD_ATEN)
        {
            int eliminado = atencionDAO.Eliminar(Convert.ToInt32(COD_ATEN));
            if (eliminado == 0) //No existe
            {
                throw new WebFaultException<string>("La atención no existe", HttpStatusCode.NotAcceptable);
            }
            return eliminado;
        }

        public List<Entidades.SHMC_ATEN> Listar()
        {
            return atencionDAO.Listar();
        }
    }
}
