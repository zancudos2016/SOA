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
        private string CadenaConexion = "Data Source=.\\SQLEXPRESS2014; Initial Catalog=DBAtenciones; Integrated Security=SSPI;";

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
    }
}