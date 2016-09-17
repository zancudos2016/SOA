using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Entidades;

namespace AccesoDatos
{
    public class DASHMC_USUA
    {
        private DAGenerics oDg;
        private Database oDb;
        private DbConnection oCon;
        /// <summary>
        /// CONTRUCTOR DE LA CLASE
        /// </summary>
        public DASHMC_USUA()
        {
            oDg = new DAGenerics("CSDEMO");
        }
        /// <summary>
        /// OBTENER EL USUARIO LOGEADO
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public IDataReader Get_P0001_USUA_LIST(SHMC_USUA oBe)
        {
            try
            {
                oDb = oDg.getDataBase();
                oCon = oDg.getConnection();
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var ocmd = oDb.GetStoredProcCommand("P0001_USUA_LIST", oBe.COD_USUA,
                                                                        oBe.ALF_PASS);
                ocmd.CommandTimeout = 2000;
                var odr = oDb.ExecuteReader(ocmd);
                return (odr);
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
    }
}
