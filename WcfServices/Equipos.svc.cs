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
    public class Equipos : IEquipos
    {
        private EquipoDAO equipoDAO = new EquipoDAO();

        public SHMC_EQUI ObtenerAtencion(int COD_EQUI)
        {
            return equipoDAO.Obtener(COD_EQUI);
        }

        public SHMC_EQUI ModificarAtencion(SHMC_EQUI equipoAModificar)
        {
            return equipoDAO.Modificar(equipoAModificar);
        }

        public List<Entidades.SHMC_EQUI> ListarAtenciones(int COD_TECN)
        {
            return equipoDAO.Listar(COD_TECN);
        }
    }
}
