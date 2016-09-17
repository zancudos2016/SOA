using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServices.Persistencia;

namespace WcfServices
{
    public class Tecnicos : ITecnicos
    {
        private TecnicoDAO tecnicoDAO = new TecnicoDAO();

        public List<Entidades.SHMC_EMPL> ListarTecnicos()
        {
            return tecnicoDAO.Listar();
        }
    }
}

