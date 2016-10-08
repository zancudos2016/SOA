using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServices.Errores;
using WcfServices.Persistencia;

namespace WcfServices
{
    public class Tecnicos : ITecnicos
    {
        private TecnicoDAO tecnicoDAO = new TecnicoDAO();

        public SHMC_EMPL ObtenerTecnico(int COD_TECN)
        {
            return tecnicoDAO.Obtener(COD_TECN);
        }

        public List<SHMC_EMPL> ListarTecnicos()
        {
            return tecnicoDAO.Listar();
        }
    }
}

