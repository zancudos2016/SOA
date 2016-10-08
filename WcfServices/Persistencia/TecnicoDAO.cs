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
        public SHMC_EMPL Obtener(int COD_TECN)
        {
            SHMC_EMPL tecnicoEncontrado = null;
            string sql = "SELECT COD_TECN, ISNULL(ALF_EMPL,'') AS ALF_EMPL " +
            "FROM SHMC_EMPL (NOLOCK) " +
            "WHERE COD_TECN = @COD_TECN";

            using (SqlConnection conexion = new SqlConnection(ConexionUtil.Cadena))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@COD_TECN", COD_TECN));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            tecnicoEncontrado = new SHMC_EMPL()
                            {
                                COD_TECN = Int32.Parse(resultado["COD_TECN"].ToString()),
                                ALF_EMPL = (string)resultado["ALF_EMPL"].ToString()
                            };
                        }
                    }
                }
            }

            return tecnicoEncontrado;
        }

        public List<SHMC_EMPL> Listar()
        {
            List<SHMC_EMPL> tecnicosEncontrados = new List<SHMC_EMPL>();
            SHMC_EMPL tecnicoEncontrado = null;
            string sql = "SELECT COD_TECN, ISNULL(ALF_EMPL,'') AS ALF_EMPL " +
            "FROM SHMC_EMPL (NOLOCK) ";

            using (SqlConnection conexion = new SqlConnection(ConexionUtil.Cadena))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            tecnicoEncontrado = new SHMC_EMPL()
                            {
                                COD_TECN = Int32.Parse(resultado["COD_TECN"].ToString()),
                                ALF_EMPL = (string)resultado["ALF_EMPL"].ToString()
                            };
                            tecnicosEncontrados.Add(tecnicoEncontrado);
                        }
                    }
                }
            }

            return tecnicosEncontrados;
        }
    }
}