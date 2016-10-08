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
        public int Registrar(SHMD_ATEN_REPO reporteACrear)
        {
            //Mensajeria
            string rutaCola = @".\private$\ReporteEntrada";
            if (!MessageQueue.Exists(rutaCola))
                MessageQueue.Create(rutaCola);
            MessageQueue cola = new MessageQueue(rutaCola);
            Message mensaje = new Message();
            mensaje.Label = "Nueva entrada";
            mensaje.Body = reporteACrear;
            cola.Send(mensaje);

            return 1;
        }

        private int Crear(SHMD_ATEN_REPO reporteACrear)
        {
            //Mensajeria
            string rutaCola = @".\private$\ReporteEntrada";
            if (!MessageQueue.Exists(rutaCola))
                MessageQueue.Create(rutaCola);
            MessageQueue cola = new MessageQueue(rutaCola);
            Message mensaje = new Message();
            mensaje.Label = "Nueva entrada";
            mensaje.Body = reporteACrear;
            cola.Send(mensaje);

            return 1;
        }

        public void RegularizarReportes()
        {
            
        }

        public SHMD_ATEN_REPO Obtener(int COD_ATEN_REPO)
        {
            SHMD_ATEN_REPO reporteEncontrado = null;
            string sql = "SELECT COD_ATEN_REPO " +
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
                                COD_ATEN_REPO = Convert.ToInt32(resultado["COD_ATEN_REPO"])
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
            "SET COD_ATEN=@COD_ATEN " +
            "WHERE COD_ATEN_REPO=@COD_ATEN_REPO";

            using (SqlConnection conexion = new SqlConnection(ConexionUtil.Cadena))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@COD_ATEN_REPO", reporteAModificar.COD_ATEN_REPO));
                    comando.Parameters.Add(new SqlParameter("@COD_ATEN", reporteAModificar.COD_ATEN));

                    comando.ExecuteNonQuery();
                }
            }

            reporteModificado = Obtener(reporteAModificar.COD_ATEN_REPO);
            return reporteModificado;
        }
    }
}