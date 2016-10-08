using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfServices.Persistencia
{
    public class UsuarioDAO
    {
        public SHMC_USUA Login(SHMC_USUA usuarioABuscar)
        {
            SHMC_USUA usuarioEncontrado = null;
            string sql = "EXEC P0001_USUA_LIST @COD_USUA, @ALF_PASS";

            using (SqlConnection conexion = new SqlConnection(ConexionUtil.Cadena))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@COD_USUA", usuarioABuscar.COD_USUA));
                    comando.Parameters.Add(new SqlParameter("@ALF_PASS", usuarioABuscar.ALF_PASS));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            usuarioEncontrado = new SHMC_USUA()
                            {
                                COD_USUA = (string)resultado["COD_USUA"],
                                ALF_PASS = (string)resultado["ALF_PASS"],
                                COD_TECN = Int32.Parse(resultado["COD_TECN"].ToString()),
                            };
                        }
                    }
                }
            }

            return usuarioEncontrado;
        }
    }
}