using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Messaging;
using System.Web;

namespace WcfServices.Persistencia
{
    public class ReporteDAO
    {
        public int Registrar(SHMD_ATEN_REPO reporteARegistrar)
        {
            //Mensajeria
            string rutaCola = @".\private$\ReporteEntrada";
            if (!MessageQueue.Exists(rutaCola))
                MessageQueue.Create(rutaCola);
            MessageQueue cola = new MessageQueue(rutaCola);
            Message mensaje = new Message();
            mensaje.Label = "Nueva entrada";
            mensaje.Body = reporteARegistrar;
            cola.Send(mensaje);

            return 1;
        }

        private int Crear(SHMD_ATEN_REPO reporteACrear)
        {
            int reporteCreado = -1;
            string sql = "INSERT INTO SHMC_ATEN (COD_ATEN,ALF_COME) " +
            "VALUES(@COD_ATEN,@ALF_COME)";

            using (SqlConnection conexion = new SqlConnection(ConexionUtil.Cadena))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@COD_ATEN", reporteACrear.COD_ATEN));
                    comando.Parameters.Add(new SqlParameter("@ALF_COME", reporteACrear.ALF_COME));

                    reporteCreado = comando.ExecuteNonQuery();
                }
            }

            return reporteCreado;
        }

        public bool RegularizarReportes()
        {
            bool reportesRegularizados = true;

            //Regularizar
            SHMD_ATEN_REPO reporte = null;
            string rutaCola = @".\private$\ReporteEntrada";
            if (!MessageQueue.Exists(rutaCola))
                MessageQueue.Create(rutaCola);

            MessageQueue cola = new MessageQueue(rutaCola);
            cola.Formatter = new XmlMessageFormatter(new Type[] { typeof(SHMD_ATEN_REPO) });

            Message mensaje = null;

            int x = cola.GetAllMessages().Count();

            for (int i = 0; i < x; i++)
            {
                mensaje = cola.Receive();
                reporte = (SHMD_ATEN_REPO)mensaje.Body;
                Crear(reporte);
            }
            //Regularizar

            return reportesRegularizados;
        }

        public SHMD_ATEN_REPO Obtener(int COD_ATEN_REPO)
        {
            SHMD_ATEN_REPO reporteEncontrado = null;
            string sql = "SELECT COD_ATEN_REPO,COD_ATEN, ISNULL(ALF_COME,' ') AS AFL_COME" +
            "FROM SHMC_ATEN_REPO (NOLOCK) " +
            "WHERE COD_ATEN_REPO=@COD_ATEN_REPO";

            using (SqlConnection conexion = new SqlConnection(ConexionUtil.Cadena))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@COD_ATEN_REPO", COD_ATEN_REPO));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            reporteEncontrado = new SHMD_ATEN_REPO()
                            {
                                COD_ATEN_REPO = Convert.ToInt32(resultado["COD_ATEN_REPO"].ToString()),
                                COD_ATEN = Convert.ToInt32(resultado["COD_ATEN"].ToString()),
                                ALF_COME = (string)resultado["ALF_COME"]
                            };
                        }
                    }
                }
            }

            return reporteEncontrado;
        }

        public SHMD_ATEN_REPO Modificar(SHMD_ATEN_REPO reporteAModificar)
        {
            SHMD_ATEN_REPO reporteModificado = null;
            string sql = "UPDATE SHMD_ATEN_REPO " +
            "SET ALF_COME=@ALF_COME " +
            "WHERE COD_ATEN_REPO=@COD_ATEN_REPO";

            using (SqlConnection conexion = new SqlConnection(ConexionUtil.Cadena))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@COD_ATEN_REPO", reporteAModificar.COD_ATEN_REPO));
                    comando.Parameters.Add(new SqlParameter("@ALF_COME", reporteAModificar.ALF_COME));

                    comando.ExecuteNonQuery();
                }
            }

            reporteModificado = Obtener(reporteAModificar.COD_ATEN_REPO);
            return reporteModificado;
        }
    }
}