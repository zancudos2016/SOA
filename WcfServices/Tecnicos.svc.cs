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

        public List<SHMC_EMPL> ListarTecnicos()
        {
            return tecnicoDAO.Listar();
        }

        public SHMC_USUA LoginTecnico(SHMC_USUA usuarioABuscar)
        {
            SHMC_USUA usuarioEncontrado = tecnicoDAO.Login(usuarioABuscar);
            if (usuarioEncontrado == null)
            {
                throw new FaultException<GeneralException>(
                    new GeneralException()
                    {
                        Codigo = "1000",
                        Descripcion = "Usuario no existe."
                    },
                    new FaultReason("Error al validar usuario."));
            }

            return usuarioEncontrado;
        }
    }
}

