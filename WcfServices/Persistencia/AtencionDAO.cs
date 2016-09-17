using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfServices.Persistencia
{
    public class AtencionDAO
    {
        private string CadenaConexion = "Data Source=.\\SQLEXPRESS2014; Initial Catalog=DBAtenciones; Integrated Security=SSPI;";

        public SHMC_ATEN Crear(SHMC_ATEN atencionACrear)
        {
            SHMC_ATEN atencionCreada = null;
            string sql = "INSERT INTO SHMC_ATEN VALUES(@COD_ATEN, @COD_PUNT_ATEN, @COD_TIPO, @FEC_ATEN, @ALF_COME, @FEC_PROG, @COD_TECN, @COD_ESTA)";

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@COD_ATEN", atencionACrear.COD_ATEN));
                    comando.Parameters.Add(new SqlParameter("@COD_PUNT_ATEN", atencionACrear.COD_PUNT_ATEN));
                    comando.Parameters.Add(new SqlParameter("@COD_TIPO", atencionACrear.COD_TIPO));
                    comando.Parameters.Add(new SqlParameter("@FEC_ATEN", atencionACrear.FEC_ATEN));
                    comando.Parameters.Add(new SqlParameter("@ALF_COME", atencionACrear.ALF_COME));
                    comando.Parameters.Add(new SqlParameter("@FEC_PROG", atencionACrear.FEC_PROG));
                    comando.Parameters.Add(new SqlParameter("@COD_TECN", atencionACrear.COD_TECN));
                    comando.Parameters.Add(new SqlParameter("@COD_ESTA", atencionACrear.COD_ESTA));

                    comando.ExecuteNonQuery();
                }
            }

            atencionCreada = Obtener(atencionACrear.COD_ATEN);
            return atencionCreada;
        }

        public SHMC_ATEN Obtener(int COD_ATEN)
        {
            SHMC_ATEN atencionEncontrada = null;
            string sql = "SELECT * FROM SHMC_ATEN WHERE COD_ATEN=@COD_ATEN";

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@COD_ATEN", COD_ATEN));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            atencionEncontrada = new SHMC_ATEN()
                            {
                                COD_ATEN = Int32.Parse(resultado["COD_ATEN"].ToString()),
                                COD_PUNT_ATEN = Int32.Parse(resultado["COD_PUNT_ATEN"].ToString()),
                                COD_TIPO = Int32.Parse(resultado["COD_TIPO"].ToString()),
                                FEC_ATEN = DateTime.Parse(resultado["FEC_ATEN"].ToString()),
                                ALF_COME = (string)resultado["ALF_COME"],
                                FEC_PROG = DateTime.Parse(resultado["FEC_PROG"].ToString()),
                                COD_TECN = Int32.Parse(resultado["COD_TECN"].ToString()),
                                COD_ESTA = Int32.Parse(resultado["COD_ESTA"].ToString())
                            };
                        }
                    }
                }
            }

            return atencionEncontrada;
        }

        public SHMC_ATEN Modificar(SHMC_ATEN atencionAModificar)
        {
            SHMC_ATEN atencionModificada = null;
            string sql = "UPDATE SHMC_ATEN SET COD_PUNT_ATEN=@COD_PUNT_ATEN, COD_TIPO=@COD_TIPO, FEC_ATEN=@FEC_ATEN, ALF_COME=@ALF_COME, FEC_PROG=@FEC_PROG, COD_TECN=@COD_TECN, COD_ESTA=@COD_ESTA WHERE COD_ATEN=@COD_ATEN";

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@COD_ATEN", atencionAModificar.COD_ATEN));
                    comando.Parameters.Add(new SqlParameter("@COD_PUNT_ATEN", atencionAModificar.COD_PUNT_ATEN));
                    comando.Parameters.Add(new SqlParameter("@COD_TIPO", atencionAModificar.COD_TIPO));
                    comando.Parameters.Add(new SqlParameter("@FEC_ATEN", atencionAModificar.FEC_ATEN));
                    comando.Parameters.Add(new SqlParameter("@ALF_COME", atencionAModificar.ALF_COME));
                    comando.Parameters.Add(new SqlParameter("@FEC_PROG", atencionAModificar.FEC_PROG));
                    comando.Parameters.Add(new SqlParameter("@COD_TECN", atencionAModificar.COD_TECN));
                    comando.Parameters.Add(new SqlParameter("@COD_ESTA", atencionAModificar.COD_ESTA));

                    comando.ExecuteNonQuery();
                }
            }

            atencionModificada = Obtener(atencionAModificar.COD_ATEN);
            return atencionModificada;
        }

        public int Eliminar(int COD_ATEN)
        {
            string sql = "DELETE FROM SHMC_ATEN WHERE COD_ATEN = @COD_ATEN";
            int eliminado = 0;
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@COD_ATEN", COD_ATEN));
                    eliminado = comando.ExecuteNonQuery();
                }
            }

            return eliminado;
        }

        public List<SHMC_ATEN> Listar()
        {
            List<SHMC_ATEN> atencionesEncontradas = new List<SHMC_ATEN>();
            SHMC_ATEN atencionEncontrada = null;
            string sql = "SELECT * FROM SHMC_ATEN WHERE COD_ESTA = 1";

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            atencionEncontrada = new SHMC_ATEN()
                            {
                                COD_ATEN = Int32.Parse(resultado["COD_ATEN"].ToString()),
                                COD_PUNT_ATEN = Int32.Parse(resultado["COD_PUNT_ATEN"].ToString()),
                                COD_TIPO = Int32.Parse(resultado["COD_TIPO"].ToString()),
                                FEC_ATEN = DateTime.Parse(resultado["FEC_ATEN"].ToString()),
                                ALF_COME = (string)resultado["ALF_COME"],
                                FEC_PROG = DateTime.Parse(resultado["FEC_PROG"].ToString()),
                                COD_TECN = Int32.Parse(resultado["COD_TECN"].ToString()),
                                COD_ESTA = Int32.Parse(resultado["COD_ESTA"].ToString())
                            };
                            atencionesEncontradas.Add(atencionEncontrada);
                        }
                    }
                }
            }

            return atencionesEncontradas;
        }
    }
}