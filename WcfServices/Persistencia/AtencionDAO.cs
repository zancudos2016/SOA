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
        //private string CadenaConexion = "Persist Security Info=False;User ID=sa;Password=1234;Initial Catalog=BDATENCIONES;Server=IMANDEV01";
        //private string CadenaConexion = "Persist Security Info=False;User ID=sa;Password=sqlserver2014;Initial Catalog=BDATENCIONES;Server=.\\SQLEXPRESS2014";
        private string CadenaConexion = "Persist Security Info=False;Integrated Security=true;Initial Catalog=BDATENCIONES;Server=localhost";

        public SHMC_ATEN Crear(SHMC_ATEN atencionACrear)
        {
            SHMC_ATEN atencionCreada = null;
            string sql = "INSERT INTO SHMC_ATEN (COD_ATEN,COD_TIPO,FEC_ATEN,ALF_COME,COD_ESTA,ALF_PTOA) VALUES(@COD_ATEN, @COD_TIPO, @FEC_ATEN, @ALF_COME, @COD_ESTA,@ALF_PTOA)";

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@COD_ATEN", atencionACrear.COD_ATEN));
                    comando.Parameters.Add(new SqlParameter("@COD_TIPO", atencionACrear.COD_TIPO));
                    comando.Parameters.Add(new SqlParameter("@FEC_ATEN", DateTime.Parse(atencionACrear.FEC_ATEN.Replace('/', '-'))));
                    comando.Parameters.Add(new SqlParameter("@ALF_COME", atencionACrear.ALF_COME));
                    comando.Parameters.Add(new SqlParameter("@COD_ESTA", atencionACrear.COD_ESTA));
                    comando.Parameters.Add(new SqlParameter("@ALF_PTOA", atencionACrear.ALF_PTOA));

                    comando.ExecuteNonQuery();
                }
            }

            atencionCreada = Obtener(atencionACrear.COD_ATEN);
            return atencionCreada;
        }

        public SHMC_ATEN Obtener(int COD_ATEN)
        {
            SHMC_ATEN atencionEncontrada = null;
            string sql = "SELECT COD_ATEN,COD_TIPO,CONVERT(NVARCHAR(10),FEC_ATEN,103) AS FEC_ATEN,ISNULL(ALF_COME,'') AS ALF_COME,ISNULL(CONVERT(NVARCHAR(10),FEC_PROG,103),'') AS FEC_PROG," +
                        "ISNULL(COD_TECN,0) AS COD_TECN, COD_ESTA, ALF_PTOA FROM SHMC_ATEN WHERE COD_ATEN=@COD_ATEN";

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
                                COD_ATEN = Convert.ToInt32(resultado["COD_ATEN"]),
                                COD_TIPO = Convert.ToInt32(resultado["COD_TIPO"]),
                                FEC_ATEN = resultado["FEC_ATEN"].ToString(),
                                ALF_COME = Convert.ToString(resultado["ALF_COME"]),
                                FEC_PROG = Convert.ToString(resultado["FEC_PROG"]),
                                COD_TECN = Convert.ToInt32(resultado["COD_TECN"].ToString()),
                                COD_ESTA = Int32.Parse(resultado["COD_ESTA"].ToString()),
                                ALF_PTOA = Convert.ToString(resultado["COD_ESTA"])
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
            string sql = "UPDATE SHMC_ATEN SET COD_TIPO=@COD_TIPO, FEC_ATEN=@FEC_ATEN, ALF_COME=@ALF_COME, FEC_PROG=@FEC_PROG, COD_TECN=@COD_TECN, COD_ESTA=@COD_ESTA, ALF_PTOA=@ALF_PTOA WHERE COD_ATEN=@COD_ATEN";

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@COD_ATEN", atencionAModificar.COD_ATEN));
                    comando.Parameters.Add(new SqlParameter("@COD_TIPO", atencionAModificar.COD_TIPO));
                    comando.Parameters.Add(new SqlParameter("@FEC_ATEN", atencionAModificar.FEC_ATEN));
                    comando.Parameters.Add(new SqlParameter("@ALF_COME", atencionAModificar.ALF_COME));
                    comando.Parameters.Add(new SqlParameter("@FEC_PROG", atencionAModificar.FEC_PROG));
                    comando.Parameters.Add(new SqlParameter("@COD_TECN", atencionAModificar.COD_TECN));
                    comando.Parameters.Add(new SqlParameter("@COD_ESTA", atencionAModificar.COD_ESTA));
                    comando.Parameters.Add(new SqlParameter("@ALF_PTOA", atencionAModificar.ALF_PTOA));

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

        public List<SHMC_ATEN> Listar(int COD_TECN)
        {
            List<SHMC_ATEN> atencionesEncontradas = new List<SHMC_ATEN>();
            SHMC_ATEN atencionEncontrada = null;
            string sql = "SELECT COD_ATEN,COD_TIPO,CONVERT(NVARCHAR(10),FEC_ATEN,103) AS FEC_ATEN,ISNULL(ALF_COME,'') AS ALF_COME,ISNULL(CONVERT(NVARCHAR(10),FEC_PROG,103),'') AS FEC_PROG," +
                        "ISNULL(COD_TECN,0) AS COD_TECN, COD_ESTA, ALF_PTOA FROM SHMC_ATEN WHERE COD_ESTA = 1 and COD_TECN = @COD_TECN";

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
                            atencionEncontrada = new SHMC_ATEN()
                            {
                                COD_ATEN = Int32.Parse(resultado["COD_ATEN"].ToString()),
                                COD_TIPO = Int32.Parse(resultado["COD_TIPO"].ToString()),
                                FEC_ATEN = resultado["FEC_ATEN"].ToString(),
                                ALF_COME = (string)resultado["ALF_COME"],
                                FEC_PROG = resultado["FEC_PROG"].ToString(),
                                COD_TECN = Int32.Parse(resultado["COD_TECN"].ToString()),
                                COD_ESTA = Int32.Parse(resultado["COD_ESTA"].ToString()),
                                ALF_PTOA = resultado["ALF_PTOA"].ToString(),
                                TIPO = fnTIPO(Int32.Parse(resultado["COD_TIPO"].ToString())),
                                ESTADO = fnESTADO(Int32.Parse(resultado["COD_ESTA"].ToString()))
                            };
                            atencionesEncontradas.Add(atencionEncontrada);
                        }
                    }
                }
            }

            return atencionesEncontradas;
        }

        private string fnTIPO(int COD_TIPO)
        {
            string tipo;
            switch (COD_TIPO)
            {
                case 1:
                    tipo = "ALTA";
                    break;
                case 2:
                    tipo = "BAJA";
                    break;
                case 3:
                    tipo = "CAMBIO";
                    break;
                case 4:
                    tipo = "ENTRENAMIENTO";
                    break;
                default:
                    tipo = "OTRO";
                    break;
            }
            return tipo;
        }

        private string fnESTADO(int COD_ESTA)
        {
            string estado;
            switch (COD_ESTA)
            {
                case 1:
                    estado = "EXITO";
                    break;
                case 2:
                    estado = "INFRAC";
                    break;
                case 3:
                    estado = "ANULD";
                    break;
                case 4:
                    estado = "CANCL";
                    break;
                default:
                    estado = "";
                    break;
            }
            return estado;
        }
    }
}