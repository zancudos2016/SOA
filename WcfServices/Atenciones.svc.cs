using Entidades;
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
        public SHMC_ATEN Crear(SHMC_ATEN atencionACrear)
        {
            if (atencionDAO.Obtener(atencionACrear.COD_ATEN) != null) //Ya existe
            {
                throw new WebFaultException<string>("La atención ya existe", HttpStatusCode.NotAcceptable);
            }

            //var oBe = atencionDAO.Obtener(atencionACrear.ALF_PTOA);

            //if (oBe.COD_TIPO == 1 && atencionACrear.COD_TIPO == 1) //El comercio ya fue instalado
            //{
            //    throw new WebFaultException<string>("El comercio ya fue instalado", HttpStatusCode.NotAcceptable);
            //}

            //if (atencionACrear.COD_TIPO==1 || atencionACrear.COD_TIPO==2) //El comercio debe tener una instalación 
            //{
            //    throw new WebFaultException<string>("El comercio ya fue instalado", HttpStatusCode.NotAcceptable);
            //}

            return atencionDAO.Crear(atencionACrear);
        }

        public SHMC_ATEN Obtener(string COD_ATEN)
        {
            var atencion = atencionDAO.Obtener(Convert.ToInt32(COD_ATEN));
            if (atencion == null) //No existe
            {
                throw new WebFaultException<string>("La atención no existe", HttpStatusCode.NotAcceptable);
            }
            return atencion;
        }

        public SHMC_ATEN Modificar(SHMC_ATEN atencionAModificar)
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

        public List<SHMC_ATEN> Listar()
        {
            return atencionDAO.Listar();
        }

        public List<SHMC_ATEN> ListarPorTecnico(string COD_TECN)
        {
            //Regulariza los reportes que se quedan encolados
            Reportes reportes = new Reportes();
            reportes.RegularizarReportes();
            //Regulariza los reportes que se quedan encolados

            return atencionDAO.Listar(Convert.ToInt32(COD_TECN));
        }
}
}
