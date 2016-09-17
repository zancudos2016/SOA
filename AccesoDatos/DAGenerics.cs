using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class DAGenerics
    {
        private Database oDb;
        private DbConnection oCon;
        /// <summary>
        /// CONSTRUCTOR DE LA CLASE
        /// </summary>
        /// <param name="DBConnectionString"></param>
        public DAGenerics(string DBConnectionString)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            oDb = factory.Create(DBConnectionString);
            oCon = oDb.CreateConnection();
        }
        /// <summary>
        /// OBTENER CUALQUIER LISTA
        /// </summary>
        /// <param name="NameProcedure"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public IDataReader getReader(string NameProcedure, params object[] args)
        {
            try
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                DbCommand oCommand = oDb.GetStoredProcCommand(NameProcedure, args);
                oCommand.CommandTimeout = 2000;
                IDataReader oReader = oDb.ExecuteReader(oCommand);
                return (oReader);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                oCon.Close();
            }
        }
        /// <summary>
        /// RETORNAR LA CONEXION
        /// </summary>
        /// <returns></returns>
        public DbConnection getConnection()
        {
            try
            {
                if (oCon.State == ConnectionState.Closed) { oCon.Open(); }
                return oCon;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        /// <summary>
        /// RETORNAR EL OBJETO BASE DE DATOS
        /// </summary>
        /// <returns></returns>
        public Database getDataBase()
        {
            try
            {
                return oDb;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
