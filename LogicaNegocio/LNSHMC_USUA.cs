using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;
using System.Collections;
using ResultSetMappers;

namespace LogicaNegocio
{
    public class LNSHMC_USUA
    {
        private DASHMC_USUA oDa;
        public LNSHMC_USUA()
        {
            oDa = new DASHMC_USUA();
        }
        /// <summary>
        /// OBTENER EL USUARIO LOGEADO
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<SHMC_USUA> Get_AP0001SNPR_LOGI_LIST(SHMC_USUA oBe)
        {
            try
            {
                using (var odr = oDa.Get_AP0001SNPR_LOGI_LIST(oBe))
                {
                    var olst = new List<SHMC_USUA>();
                    ((IList)olst).LoadFromReader<SHMC_USUA>(odr);
                    return (olst);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
