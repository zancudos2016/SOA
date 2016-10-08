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

        public SHMC_EQUI ObtenerEquipo(int COD_EQUI)
        {
            return equipoDAO.Obtener(COD_EQUI);
        }

        public SHMC_EQUI ModificarEquipo(SHMC_EQUI equipoAModificar)
        {
            return equipoDAO.Modificar(equipoAModificar);
        }

        public List<SHMC_EQUI> ListarEquipos(int COD_TECN)
        {
            return equipoDAO.Listar(COD_TECN);
        }
    }
}
