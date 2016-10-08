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
    public class Almacenes : IAlmacenes
    {
        private AlmacenDAO almacenDAO = new AlmacenDAO();

        public SHMC_ALMA ObtenerAlmacen(int COD_ALMA)
        {
            return almacenDAO.Obtener(COD_ALMA);
        }

        public List<SHMC_ALMA> ListarAlmacenes()
        {
            return almacenDAO.Listar();
        }
    }
}
