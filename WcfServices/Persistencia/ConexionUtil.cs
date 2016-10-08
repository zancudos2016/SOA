using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfServices.Persistencia
{
    public class ConexionUtil
    {
        public static string Cadena
        {
            get
            {
                //"Persist Security Info=False;User ID=sa;Password=1234;Initial Catalog=BDATENCIONES;Server=IMANDEV01";
                return "Persist Security Info=False;User ID=sa;Password=1234;Initial Catalog=BDATENCIONES;Server=192.168.1.6";
            }
        }
    }
}
