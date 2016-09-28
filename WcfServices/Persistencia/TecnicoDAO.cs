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