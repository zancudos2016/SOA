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
    public class Reportes : IReportes
    {
        private ReporteDAO reporteDAO = new ReporteDAO();

        public int RegistarReporte(SHMD_ATEN_REPO reporteARegistrar)
        {
            return reporteDAO.Registrar(reporteARegistrar);
        }

        public bool RegularizarReportes()
        {
            return reporteDAO.RegularizarReportes();
        }

        public SHMD_ATEN_REPO ObtenerReporte(int COD_ATEN_REPO)
        {
            return reporteDAO.Obtener(COD_ATEN_REPO);
        }

        public SHMD_ATEN_REPO ModificarReporte(SHMD_ATEN_REPO reporteAModificar)
        {
            return reporteDAO.Modificar(reporteAModificar);
        }
    }
}
