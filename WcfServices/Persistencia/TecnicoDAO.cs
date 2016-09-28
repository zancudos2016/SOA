using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfServices.Persistencia
{
    public class TecnicoDAO
    {
        //private string CadenaConexion = "Data Source=.\\SQLEXPRESS; Initial Catalog=BDAtenciones; Integrated Security=SSPI;";
        //private string CadenaConexion = "Persist Security Info=False;User ID=sa;Password=sqlserver2014;Initial Catalog=BDATENCIONES;Server=.\\SQLEXPRESS2014";
        private string CadenaConexion = "Persist Security Info=False;Integrated Security=true;Initial Catalog=BDATENCIONES;Server=localhost";

        public List<SHMC_EMPL> Listar()
        {
            List<SHMC_EMPL> tecnicosEncontradas = new List<SHMC_EMPL>();
            SHMC_EMPL tecnicoEncontrada = null;
            string sql = "SELECT * FROM SHMC_EMPL";

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            tecnicoEncontrada = new SHMC_EMPL()
                            {
                                COD_TECN = Int32.Parse(resultado["COD_TECN"].ToString()),
                                ALF_EMPL = (string)resultado["ALF_EMPL"],
                            };
                            tecnicosEncontradas.Add(tecnicoEncontrada);
                        }
                    }
                }
            }

            return tecnicosEncontradas;
        }

        public SHMC_USUA Login(SHMC_USUA usuarioABuscar)
        {
            SHMC_USUA usuarioEncontrado = null;
            string sql = "EXEC P0001_USUA_LIST @COD_USUA, @ALF_PASS";

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
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