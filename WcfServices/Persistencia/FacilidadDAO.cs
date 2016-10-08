using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfServices.Persistencia
{
    public class FacilidadDAO
    {
        public List<SHMC_FACI> Listar()
        {
            List<SHMC_FACI> facilidadesEncontradas = new List<SHMC_FACI>();
            SHMC_FACI facilidadEncontrada = null;
            string sql = "SELECT COD_FACI, ISNULL(ALF_FACI,'') AS ALF_FACI " +
            "FROM SHMC_FACI (NOLOCK) ";

            using (SqlConnection conexion = new SqlConnection(ConexionUtil.Cadena))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            facilidadEncontrada = new SHMC_FACI()
                            {
                                COD_FACI = Int32.Parse(resultado["COD_FACI"].ToString()),
                                ALF_FACI = (string)resultado["ALF_FACI"].ToString()
                            };
                            facilidadesEncontradas.Add(facilidadEncontrada);
                        }
                    }
                }
            }

            return facilidadesEncontradas;
        }
    }
}