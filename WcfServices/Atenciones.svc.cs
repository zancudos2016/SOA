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
    public class Atenciones : IAtenciones
    {
        private AtencionDAO atencionDAO = new AtencionDAO();

        public Entidades.SHMC_ATEN CrearAtencion(Entidades.SHMC_ATEN atencionACrear)
        {
            if (atencionDAO.Obtener(atencionACrear.COD_ATEN) != null) //Ya existe
            {
                throw new FaultException<GeneralException>(
                    new GeneralException()
                    {
                        Codigo = "101",
                        Descripcion = "La atención ya existe."
                    },
                    new FaultReason("Error al intentar creación."));
            }
            return atencionDAO.Crear(atencionACrear);
        }

        public Entidades.SHMC_ATEN ObtenerAtencion(int COD_ATEN)
        {
            return atencionDAO.Obtener(COD_ATEN);
        }

        public Entidades.SHMC_ATEN ModificarAtencion(Entidades.SHMC_ATEN atencionAModificar)
        {
            return atencionDAO.Modificar(atencionAModificar);
        }

        public int EliminarAtencion(int COD_ATEN)
        {
            int eliminado = atencionDAO.Eliminar(COD_ATEN);
            if (eliminado == 0) //No existe
            {
                throw new FaultException<GeneralException>(
                    new GeneralException()
                    {
                        Codigo = "102",
                        Descripcion = "La atención no existe."
                    },
                    new FaultReason("Error al intentar eliminar."));
            }
            return eliminado;
        }

        public List<Entidades.SHMC_ATEN> ListarAtenciones()
        {
            return atencionDAO.Listar();
        }
    }
}
