using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfServices.Persistencia
{
    public class AlmacenDAO
    {
        public SHMC_ALMA Obtener(int COD_ALMA)
        {
            SHMC_ALMA almacenEncontrado = null;
            string sql = "SELECT COD_ALMA, ISNULL(ALF_ALMA,'') AS ALF_ALMA " +
            "FROM SHMC_ALMA (NOLOCK) " +
            "WHERE COD_ALMA = @COD_ALMA";

            using (SqlConnection conexion = new SqlConnection(ConexionUtil.Cadena))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@COD_ALMA", COD_ALMA));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            almacenEncontrado = new SHMC_ALMA()
                            {
                                COD_ALMA = Int32.Parse(resultado["COD_ALMA"].ToString()),
                                ALF_ALMA = (string)resultado["ALF_ALMA"].ToString()
                            };
                        }
                    }
                }
            }

            return almacenEncontrado;
        }

        public List<SHMC_ALMA> Listar()
        {
            List<SHMC_ALMA> almacenesEncontrados = new List<SHMC_ALMA>();
            SHMC_ALMA almacenEncontrado = null;
            string sql = "SELECT COD_ALMA, ISNULL(ALF_ALMA,'') AS ALF_ALMA " +
            "FROM SHMC_ALMA (NOLOCK) ";

            using (SqlConnection conexion = new SqlConnection(ConexionUtil.Cadena))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            almacenEncontrado = new SHMC_ALMA()
                            {
                                COD_ALMA = Int32.Parse(resultado["COD_ALMA"].ToString()),
                                ALF_ALMA = (string)resultado["ALF_ALMA"].ToString()
                            };
                            almacenesEncontrados.Add(almacenEncontrado);
                        }
                    }
                }
            }

            return almacenesEncontrados;
        }
    }
}