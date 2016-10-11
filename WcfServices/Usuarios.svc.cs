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
    //este servicio contiene el metodo de login
    public class Usuarios : IUsuarios
    {
        private UsuarioDAO usuarioDAO = new UsuarioDAO();

        public SHMC_USUA LoginUsuario(SHMC_USUA usuarioABuscar)
        {
            SHMC_USUA usuarioEncontrado = usuarioDAO.Login(usuarioABuscar);
            
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
