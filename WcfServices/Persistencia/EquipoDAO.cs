using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfServices.Persistencia
{
    public class EquipoDAO
    {
        //private string CadenaConexion = "Persist Security Info=False;User ID=sa;Password=123456;Initial Catalog=BDATENCIONES;Server=.\\SQLEXPRESS";
        //private string CadenaConexion = "Persist Security Info=False;User ID=sa;Password=sqlserver2014;Initial Catalog=BDATENCIONES;Server=.\\SQLEXPRESS2014";
        private string CadenaConexion = "Persist Security Info=False;Integrated Security=true;Initial Catalog=BDATENCIONES;Server=localhost";

        public SHMC_EQUI Obtener(int COD_EQUI)
        {
            SHMC_EQUI equipoEncontrado = null;
            string sql = "SELECT COD_EQUI,ISNULL(ALF_SERI,'') AS ALF_SERI,COD_ESTA,COD_TIPO_UBIC," +
            "ISNULL(COD_ALMA,0) AS COD_ALMA,ISNULL(COD_TECN,0) AS COD_TECN,ISNULL(COD_PUNT_ATEN,0) AS COD_PUNT_ATEN " +
            "FROM SHMC_EQUI (NOLOCK) " +
            "WHERE COD_EQUI = @COD_EQUI";

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@COD_EQUI", COD_EQUI));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            equipoEncontrado = new SHMC_EQUI()
                            {
                                COD_EQUI = Int32.Parse(resultado["COD_EQUI"].ToString()),
                                ALF_SERI = (string)resultado["ALF_SERI"].ToString(),
                                COD_ESTA = Int32.Parse(resultado["COD_ESTA"].ToString()),
                                COD_TIPO_UBIC = Int32.Parse(resultado["COD_TIPO_UBIC"].ToString()),
                                COD_ALMA = Int32.Parse(resultado["COD_ALMA"].ToString()),
                                COD_TECN = Int32.Parse(resultado["COD_TECN"].ToString()),
                                COD_PUNT_ATEN = Int32.Parse(resultado["COD_PUNT_ATEN"].ToString()),
                            };
                        }
                    }
                }
            }

            return equipoEncontrado;
        }

        public SHMC_EQUI Modificar(SHMC_EQUI equipoAModificar)
        {
            SHMC_EQUI equipoModificada = null;
            string sql = "UPDATE SHMC_EQUI " +
                "SET ALF_SERI=@ALF_SERI, " +
                "COD_ESTA=@COD_ESTA, " +
                "COD_TIPO_UBIC=@COD_TIPO_UBIC, " +
                "COD_ALMA=@COD_ALMA, " +
                "COD_TECN=@COD_TECN, " +
                "COD_PUNT_ATEN=@COD_PUNT_ATEN " +
                "WHERE COD_EQUI=@COD_EQUI";

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@COD_EQUI", equipoAModificar.COD_EQUI));
                    comando.Parameters.Add(new SqlParameter("@ALF_SERI", equipoAModificar.ALF_SERI));
                    comando.Parameters.Add(new SqlParameter("@COD_ESTA", equipoAModificar.COD_ESTA));
                    comando.Parameters.Add(new SqlParameter("@COD_TIPO_UBIC", equipoAModificar.COD_TIPO_UBIC));
                    comando.Parameters.Add(new SqlParameter("@COD_ALMA", equipoAModificar.COD_ALMA));
                    comando.Parameters.Add(new SqlParameter("@COD_TECN", equipoAModificar.COD_TECN));
                    comando.Parameters.Add(new SqlParameter("@COD_PUNT_ATEN", equipoAModificar.COD_PUNT_ATEN));

                    comando.ExecuteNonQuery();
                }
            }

            equipoModificada = Obtener(equipoAModificar.COD_EQUI);
            return equipoModificada;
        }

        public List<SHMC_EQUI> Listar(int COD_TECN)
        {
            List<SHMC_EQUI> equiposEncontrados = new List<SHMC_EQUI>();
            SHMC_EQUI equipoEncontrado = null;
            string sql = "SELECT COD_EQUI,ISNULL(ALF_SERI,'') AS ALF_SERI,COD_ESTA,COD_TIPO_UBIC," +
            "ISNULL(COD_ALMA,0) AS COD_ALMA,ISNULL(COD_TECN,0) AS COD_TECN,ISNULL(COD_PUNT_ATEN,0) AS COD_PUNT_ATEN " +
            "FROM SHMC_EQUI (NOLOCK) " +
            "WHERE COD_TECN = @COD_TECN";

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@COD_TECN", COD_TECN));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            equipoEncontrado = new SHMC_EQUI()
                            {
                                COD_EQUI = Int32.Parse(resultado["COD_EQUI"].ToString()),
                                ALF_SERI = (string)resultado["ALF_SERI"].ToString(),
                                COD_ESTA = Int32.Parse(resultado["COD_ESTA"].ToString()),
                                COD_TIPO_UBIC = Int32.Parse(resultado["COD_TIPO_UBIC"].ToString()),
                                COD_ALMA = Int32.Parse(resultado["COD_ALMA"].ToString()),
                                COD_TECN = Int32.Parse(resultado["COD_TECN"].ToString()),
                                COD_PUNT_ATEN = Int32.Parse(resultado["COD_PUNT_ATEN"].ToString()),
                            };
                            equiposEncontrados.Add(equipoEncontrado);
                        }
                    }
                }
            }

            return equiposEncontrados;
        }
    }
}